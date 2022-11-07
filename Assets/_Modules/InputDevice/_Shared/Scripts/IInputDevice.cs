using System;
using UnityEngine;

namespace InputDevices
{
    public interface IInputDevice
    {
        event Action<Vector2> OnPlayerDirectionChanged;
        event Action OnPlaceBomb;
    }
}