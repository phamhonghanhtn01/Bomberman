using System;
using StateMachines;

namespace Actors
{
    public class Actor : MachineBehaviour
    {
        public IHealth Health => health ?? NullHealth.Instance;
        public IAnimator Animator => animator ?? NullAnimator.Instance;
        public IGraphic Graphic => graphic ?? NullGraphic.Instance;
        public IInput Input => input ?? NullInput.Instance; //NHẬN GIAO TIẾP TƯƠNG TÁC VỚI PLAYER
        public IMovement Movement => movement ?? NullMovement.Instance;
        public IStatusEngine StatusEngine => statusEngine ?? NullStatusEngine.Instance;
        public IAbilityEngine AbilityEngine => abilityEngine ?? NullAbilityEngine.Instance;
            
        private IHealth health;
        private IAnimator animator;
        private IGraphic graphic;
        private IInput input;
        private IMovement movement;
        private IStatusEngine statusEngine;
        private IAbilityEngine abilityEngine;

        protected virtual void Awake()
        {
            health = GetComponent<IHealth>();
            animator = GetComponent<IAnimator>();
        }
    }
}