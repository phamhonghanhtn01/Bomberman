using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TypeReferences;
using UnityEngine;

namespace StateMachines
{
    public abstract class MachineBehaviour : MonoBehaviour, MachineInterface
    {
#if UNITY_EDITOR
        [SerializeField, ReadOnly, BoxGroup("Editor")]
        private string _currentStateName;

        [SerializeField, ReadOnly, BoxGroup("Editor")]
        private string _prevStateName;
#endif

        [SerializeField, ClassImplements(typeof(StateInterface))]
        private ClassTypeReference _startingState;

        private StateInterface PreviousState { get; set; }
        private StateInterface currentState { get; set; }
        private StateInterface NextState { get; set; }
        private StateInterface InitialState { get; set; }

        private bool OnEnter { get; set; }
        private bool OnExit { get; set; }
        public bool IsInDefaultState => currentState.GetType() == _startingState.Type;

        [ShowInInspector]
        private readonly Dictionary<Type, StateInterface> states = new Dictionary<Type, StateInterface>();

        public bool IsInitialized { private set; get; }

        public Type StartingStateType => _startingState;

        /// <summary>
        /// REQUIRES IMPL
        ///
        ///     Add states to the machine with calls to AddState<>()
        ///
        ///     When all states have been added notify the machine
        ///         which state to start in with SetInitialState<>()
        /// </summary>
        public virtual void AddStatesManually()
        {
        }

        public void BackToDefaultState()
        {
            ChangeState(_startingState);
        }

        public void BackToPreviousState()
        {
            if (PreviousState != null)
                ChangeState(PreviousState.GetType());
            else
                BackToDefaultState();
        }

        public void ChangeToEmptyState()
        {
            NextState = EmptyState.NullState;
            OnExit = true;
        }

        public bool IsInEmptyState()
        {
            return currentState == EmptyState.NullState;
        }

        public virtual void InitializeStateMachine()
        {
            IsInitialized = true;
            AddState(EmptyState.NullState);

            foreach (var state in GetComponents<StateInterface>())
            {
                AddState(state);
            }

            AddStatesManually();

            // If initial state was not set
            if (InitialState == null)
            {
                // If starting type was set
                if (_startingState.Type != default(Type))
                    SetInitialState(_startingState.Type);
                // If not then start at Empty State
                else
                    InitialState = EmptyState.NullState;
            }

            PreviousState = InitialState;
            currentState = InitialState;
            if (null == currentState)
            {
                throw new Exception("\n" + name + ".nextState is null on Initialize()!\tDid you forget to call SetInitialState()?\n");
            }

            foreach (KeyValuePair<Type, StateInterface> pair in states)
            {
                pair.Value.InitializeStateMachine();
            }

            OnEnter = true;
            OnExit = false;
        }

        public virtual void Reset()
        {
            PreviousState = InitialState;
            currentState = InitialState;
            OnEnter = true;
            OnExit = false;

            foreach (KeyValuePair<Type, StateInterface> pair in states)
            {
                pair.Value.Reset();
            }
        }

        protected virtual void Update()
        {
            if (!IsInitialized) return;

            if (OnExit)
            {
                currentState.Exit();
                PreviousState = currentState;
                currentState = NextState;
                NextState = null;

                OnEnter = true;
                OnExit = false;
            }

            if (OnEnter)
            {
#if UNITY_EDITOR
                _currentStateName = currentState.GetType().Name;
                _prevStateName = PreviousState.GetType().Name;
#endif
                currentState.Enter();

                OnEnter = false;
            }

            try
            {
                currentState.Execute();
            }
            catch (NullReferenceException e)
            {
                if (null == InitialState)
                {
                    throw new Exception("\n" + name +
                                        ".currentState is null when calling Execute()!\tDid you set initial state?\n" +
                                        e.StackTrace);
                }
                else
                {
                    throw new Exception("\n" + name + ".currentState " + currentState.GetType().Name +
                                        " is null when calling Execute()!\tDid you change state to a valid state?\n" +
                                        e.StackTrace);
                }
            }
        }

        public void SetInitialState<T>() where T : StateInterface
        {
            InitialState = states[typeof(T)];
        }

        public void SetInitialState(Type T)
        {
            InitialState = states[T];
        }

        public virtual void ChangeState<T>() where T : StateInterface
        {
            ChangeState(typeof(T));
        }

        public virtual void ChangeState(Type T)
        {
            //if (null != nextState)
            //{
            //    throw new System.Exception(name + " is already changing states, you must wait to call ChangeState()!\n");
            //}

            if (!states.ContainsKey(T))
            {
                Debug.LogError("Missing state " + T.Name + " on machine " + gameObject.name);
                return;
            }

            NextState = states[T];

            //try
            //{
            //    nextState = states[T];
            //}
            //catch (System.Collections.Generic.KeyNotFoundException e)
            //{
            //    throw new System.Exception("\n" + name + ".ChangeState() cannot find the state in the machine!\tDid you add state " + T.Name + " you are trying to change to?\n" + e.StackTrace);
            //}

            OnExit = true;
        }

        public bool IsPreviousState<T>(bool allowBaseType = false) where T : StateInterface
        {
            return allowBaseType ? PreviousState.GetType().BaseType == typeof(T) : PreviousState.GetType() == typeof(T);
        }

        public bool IsCurrentState<T>(bool allowBaseType = false) where T : StateInterface
        {
            return allowBaseType ? currentState is T : currentState.GetType() == typeof(T);
        }

        public bool IsCurrentState(Type T)
        {
            return currentState.GetType() == T;
        }

        public bool AddState<T>(StateInterface state)
        {
            var type = typeof(T);

            if (HasState(type)) return false;
            state.machine = this;
            states.Add(type, state);
            return true;
        }

        public bool AddState(StateInterface state)
        {
            var type = state.GetType();

            if (HasState(type)) return false;
            state.machine = this;
            states.Add(type, state);
            return true;
        }

        public bool AddState(Type T)
        {
            if (HasState(T)) return false;
            var item = GetComponent(T);

            if (item == null)
            {
                item = gameObject.AddComponent(T);
            }

            ((StateInterface) item).machine = this;

            states.Add(T, (StateInterface) item);
            return true;
        }

        public void RemoveState<T>() where T : StateInterface
        {
            states.Remove(typeof(T));
        }

        public void RemoveState(Type T)
        {
            states.Remove(T);
        }

        public bool HasState<T>() where T : StateInterface
        {
            return states.ContainsKey(typeof(T));
        }

        public bool HasState(Type T)
        {
            return states.ContainsKey(T);
        }

        public void RemoveAllStates()
        {
            states.Clear();
        }

        public T CurrentState<T>() where T : StateInterface
        {
            return (T) currentState;
        }

        public StateInterface CurrentState()
        {
            return currentState;
        }

        public T GetState<T>() where T : StateInterface
        {
            if (states.ContainsKey(typeof(T)))
                return (T) states[typeof(T)];
            else
                Debug.LogError("Missing State: " + typeof(T));
            return default(T);
        }

        public StateInterface GetState(Type type)
        {
            if (states.ContainsKey(type)) 
                return states[type];
            else
                Debug.LogError("Missing State: " + type);
            return null;
        }
    }
}