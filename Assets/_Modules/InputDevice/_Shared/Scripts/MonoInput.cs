using System;
using Actors;
using UnityEngine;

namespace InputDevices
{
    public abstract class MonoInput : MonoBehaviour, IInputDevice
    {
        public abstract event Action<Vector2> OnPlayerDirectionChanged;
        public abstract event Action OnPlaceBomb;
    }
}