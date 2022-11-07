using System;
using UnityEngine;

namespace InputDevices
{
    public class KeyboardDevice : MonoInput
    {
        public override event Action<Vector2> OnPlayerDirectionChanged;
        public override event Action OnPlaceBomb;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("key A");
                OnPlayerDirectionChanged?.Invoke(Vector2.left);
            }if (Input.GetKeyDown(KeyCode.W))
            {                
                Debug.Log("key W");
                OnPlayerDirectionChanged?.Invoke(Vector2.up);
            }if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("key S");

                OnPlayerDirectionChanged?.Invoke(Vector2.down);
            }if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("key D");
                OnPlayerDirectionChanged?.Invoke(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("key Space");
                OnPlaceBomb?.Invoke();
            }
        }


    }
}