using System;

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
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public void SubscribeControl(ControlCode controlCode, Action action)
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeControl(ControlCode controlCode, Action action)
        {
            throw new NotImplementedException();
        }

        public void InvokeControl(ControlCode controlCode)
        {
            throw new NotImplementedException();
        }
    }
}