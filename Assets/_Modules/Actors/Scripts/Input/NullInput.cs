using System;
using UnityEngine;

namespace Actors
{
    public class NullInput : IInput
    {
        public static readonly NullInput Instance = new NullInput();

        private NullInput()
        {
            
        }
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

        public void SetDirection(float vertical, float horizontal)
        {
            
        }

        public void SetDirectionVex(Vector2 newDirection)
        {
            throw new NotImplementedException();
        }

        public void SetDirection(float Direction)
        {
            
        }
    }
}