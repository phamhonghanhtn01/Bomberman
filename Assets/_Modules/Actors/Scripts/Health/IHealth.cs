using System;

namespace Actors
{
    public interface IHealth
    {
        event Action<IHealth> OnValueChanged;
        bool IsInitialized { get; }
        float CurrentHealth { get; }
        float MaxHealth { get; }
        float MinHealth { get; }
        bool Invincible { get; }
        float HealthPercentage { get; }
        void Initialize(float startingHealth);
        void Reset();
        void Damage(float damage);
        void Healing(float amount);
        void SetInvincible(bool invincible);
        void SetMaxHealth(float maxHealth);
        void SetMinHealth(float minHealth);
    }
}