using System;
using UnityEngine;

//joystick "nhan input direction" UI xu ly rieng nhận input từ màn hình thiết bị --> input xu ly direction (up move LR), dat bom-->  
namespace Actors
{
    public enum ControlCode
    {
        PlaceBomb = 1,
        MoveLeft = 2,
        MoveRight = 3,
        MoveUp = 4,
        MoveDown = 5
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