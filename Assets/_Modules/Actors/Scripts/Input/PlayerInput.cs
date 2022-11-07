using System;
using InputDevices;
using UnityEngine;

namespace Actors
{
    public class PlayerInput : MonoBehaviour, IInput
    {
        [SerializeField] private MonoInput inputDevice;
        public event Action<IInput> OnInputDirection;

        public Rigidbody2D rigidbody;
        private Vector2 direction = Vector2.down;
        public float speed = 5f;
        
        public bool Active { get; set; }
        public bool Lock { get; set; }
        public void Initialize(Actor actor)
        {
            inputDevice.OnPlayerDirectionChanged += ChangeDirectionHandler;
            inputDevice.OnPlaceBomb += PlaceBombHandler;
        }

        private void PlaceBombHandler()
        {
            InvokeControl(ControlCode.PlaceBomb);
        }

        private void ChangeDirectionHandler(Vector2 direction)
        {
            float angle = Vector2.Angle(direction, Vector2.left);
            if (angle > 0 )
            {
                
            }
            Debug.Log("angle + " + angle );
        }

        public void Tick()
        {
            
        }

        public void SubscribeControl(ControlCode controlCode, Action action)
        {
            
        }

        public void UnsubscribeControl(ControlCode controlCode, Action action)
        {
            
        }

        public void InvokeControl(ControlCode controlCode)
        {
            
        }
        
    }
}