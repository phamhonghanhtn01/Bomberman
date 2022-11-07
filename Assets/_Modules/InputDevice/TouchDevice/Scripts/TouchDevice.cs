using System;
using UnityEngine;
using UnityEngine.UI;

namespace InputDevices
{
    public class TouchDevice : MonoInput
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Button placeBombBtn;
        
        public override event Action<Vector2> OnPlayerDirectionChanged;
        public override event Action OnPlaceBomb;

        private void Awake()
        {
            
            placeBombBtn.onClick.AddListener(() => OnPlaceBomb?.Invoke());
        }
    }
}