using System;

namespace Actors
{
    public interface IHealth
    {
        event Action<IHealth> OnValueChanged;
        bool IsInitialized { set; get; }
        float CurrentHealth { set; get; }
        float MaxHealth { set; get; }
        float MinHealth { set; get; }
        bool Invincible { set; get; }
        float HealthPercentage { get; }
        void Initialize();
        void Reset();
        void Damage(float damage);
        void Healing(float amount);
    }
}