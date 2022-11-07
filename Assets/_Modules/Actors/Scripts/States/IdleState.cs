using StateMachines;

namespace Actors.States
{
    public class IdleState : State<Actor>
    {
        public override void Enter()
        {
            base.Enter();
            machine.Animator.Play("Idle");
            machine.Input.SubscribeControl(ControlCode.MoveUp, MoveHandler);
            machine.Input.SubscribeControl(ControlCode.MoveRight, MoveHandler);
            machine.Input.SubscribeControl(ControlCode.MoveDown, MoveHandler);
            machine.Input.SubscribeControl(ControlCode.MoveLeft, MoveHandler);

        }

        public override void Exit()
        {
            base.Exit();
            machine.Input.UnsubscribeControl(ControlCode.MoveUp, MoveHandler);
            machine.Input.UnsubscribeControl(ControlCode.MoveRight, MoveHandler);
            machine.Input.UnsubscribeControl(ControlCode.MoveDown, MoveHandler);
            machine.Input.UnsubscribeControl(ControlCode.MoveLeft, MoveHandler);
        }

        private void MoveHandler()
        {
            machine.ChangeState<MoveState>();
        }
    }
}