using System;
using StateMachines;

namespace Actors
{
    public class Actor : MachineBehaviour
    {
        public IHealth Health { private set; get; }
        public IAnimator Animator { private set; get; }
        public IMovement Movement { private set; get; }
        public IInput Input { private set; get; }
        public IStatusEngine StatusEngine { private set; get; }
        public IAbilityEngine AbilityEngine { private set; get; }
        public IGraphic GraphicEngine { private set; get; }


        protected virtual void Awake()
        {
            Health = GetComponent<IHealth>();
            Animator = GetComponent<IAnimator>();
        }
    }
}