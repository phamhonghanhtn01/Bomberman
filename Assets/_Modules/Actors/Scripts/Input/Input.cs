using System;
using UnityEngine;

namespace Actors
{
    public class Input : MonoBehaviour, IInput
    {
        public event Action<IInput> OnInputDirection;

        public Rigidbody2D rigidbody;
        private Vector2 direction = Vector2.down;
        public float speed = 5f;
        
        public bool Active { get; set; }
        public bool Lock { get; set; }
        public void Initialize(Actor actor)
        {
            
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
        
        private void FixedUpdate()
        {
            Vector2 position = rigidbody.position;
            Vector2 translation = direction * speed * Time.fixedDeltaTime;
            Debug.Log("translation   " + translation);
            rigidbody.MovePosition(position + translation);
            Debug.Log("MovePosition   " + position + translation);
        }
        public void SetDirection(float horizontal, float vertical)
        {
              direction = Vector2.right * vertical + Vector2.up * horizontal;
        }
        public void SetDirectionVex(Vector2 newDirection)
        {
            direction = newDirection;

        }
        
    }
}