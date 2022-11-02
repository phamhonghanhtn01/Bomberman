using System;

namespace Actors
{
    public enum ControlCode
    {
    }

    public interface IInput
    {
        bool Active { set; get; }
        bool Lock { set; get; }

        void Initialize(Actor actor); 
        void Tick();
        void SubscribeControl(ControlCode controlCode, Action action);
        void UnsubscribeControl(ControlCode controlCode, Action action);
        void InvokeControl(ControlCode controlCode);
    }
}