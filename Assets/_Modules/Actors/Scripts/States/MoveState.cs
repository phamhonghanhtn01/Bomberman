using StateMachines;
using UnityEngine;

namespace Actors.States
{
    public class MoveState : State<Actor>
    {
        
        public override void Enter()
        {
            base.Enter();
            machine.Input.SubscribeControl(ControlCode.MoveUp, MoveUpHandler);
            machine.Input.SubscribeControl(ControlCode.MoveRight, MoveRightHandler);
            machine.Input.SubscribeControl(ControlCode.MoveDown, MoveDownHandler);
            machine.Input.SubscribeControl(ControlCode.MoveLeft, MoveLeftHandler);

        }

        private void MoveLeftHandler()
        {
            Debug.Log("move + "  + "MoveLeft");
            machine.Movement.Move();

        }

        private void MoveDownHandler()
        {
            Debug.Log("move + "  + "MoveDown");

            machine.Movement.Move();
        }

        private void MoveRightHandler()
        {
            Debug.Log("move + "  + "MoveRight");

            machine.Movement.Move();
        }

        private void MoveUpHandler()
        {
            Debug.Log("move + "  + "MoveUp");

            machine.Movement.Move();
        }

        public override void Exit()
        {
            base.Exit();
            machine.Input.UnsubscribeControl(ControlCode.MoveUp, MoveUpHandler);
            machine.Input.UnsubscribeControl(ControlCode.MoveRight, MoveRightHandler);
            machine.Input.UnsubscribeControl(ControlCode.MoveDown, MoveDownHandler);
            machine.Input.UnsubscribeControl(ControlCode.MoveLeft, MoveLeftHandler);
        }

    }
}