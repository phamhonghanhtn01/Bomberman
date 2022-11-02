using System;

namespace Actors
{
    public class NullHealth : IHealth
    {
        public static readonly NullHealth Instance = new NullHealth();

        private NullHealth()
        {
        }

        public event Action<IHealth> OnValueChanged;
        public bool IsInitialized { get; set; }
        public float CurrentHealth { get; set; }
        public float MaxHealth { get; set; }
        public float MinHealth { get; set; }
        public bool Invincible { get; set; }
        public float HealthPercentage { get; }
        
        public void Initialize()
        {
        }

        public void Reset()
        {
        }

        public void Damage(float damage)
        {
        }

        public void Healing(float amount)
        {
        }
    }
}