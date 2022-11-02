using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Actors
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action<IHealth> OnValueChanged;
        public bool IsInitialized { private set; get; }
        [ShowInInspector] public float MaxHealth { private set; get; }
        [ShowInInspector] public float MinHealth { private set; get; }

        [ShowInInspector]
        public float CurrentHealth
        {
            set
            {
                if (currentHealth != value)
                {
                    OnValueChanged?.Invoke(this);
                }

                currentHealth = value;
            }
            get => currentHealth;
        }


        public bool Invincible { get; private set; }
        public float HealthPercentage => CurrentHealth / MaxHealth;

        private float currentHealth;
        
        public void Initialize(float startingHealth)
        {
            CurrentHealth = startingHealth;
            IsInitialized = true;
        }

        public void Reset()
        {
        }

        public void Damage(float damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, MinHealth, MaxHealth);
        }

        public void Healing(float amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, MinHealth, MaxHealth);
        }

        public void SetInvincible(bool invincible)
        {
            Invincible = invincible;
        }

        public void SetMaxHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
        }

        public void SetMinHealth(float minHealth)
        {
            MinHealth = minHealth;
        }
    }
}