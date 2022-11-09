using System;
using InputDevices;
using Unity.VisualScripting;
using UnityEngine;

namespace Actors
{
    public class PlayerInput : MonoBehaviour, IInput
    {
        [SerializeField] private MonoInput inputDevice;
        public event Action<IInput> OnInputDirection;

        public Rigidbody2D rigidbody;
        private Vector2 direction ;
        public float speed ;
        
        public bool Active { get; set; }
        public bool Lock { get; set; }
        public void Initialize(Actor actor)
        {
            inputDevice.OnPlayerDirectionChanged += ChangeDirectionHandler;
            inputDevice.OnPlaceBomb += PlaceBombHandler;
        }

        private void PlaceBombHandler()
        {
            InvokeControl(ControlCode.PlaceBomb);
        }

        private void ChangeDirectionHandler(Vector2 direction)
        {
            float angle = Vector2.Angle(direction, Vector2.right);
            Debug.Log("angle + " + angle );
            if (angle == 0)//angle = 0
            {
                InvokeControl(ControlCode.MoveRight);
            }
            if (angle == 90)//angle = 90
            {
                InvokeControl(ControlCode.MoveUp);
            }if (angle == 180)//angle = 180
            {
                InvokeControl(ControlCode.MoveLeft);
            }
            
        }

        public void Tick()
        {
            
        }

        public void SubscribeControl(ControlCode controlCode, Action action)
        {
            
        }

        public void UnsubscribeControl(ControlCode controlCode, Action action)
        {
            
        }

        

        public void InvokeControl(ControlCode controlCode)
        {
            if (controlCode == ControlCode.MoveRight)
            {
                Debug.Log("move r ");
                rigidbody.velocity = Vector3.right * Time.deltaTime * speed;
            }if (controlCode == ControlCode.MoveLeft)
            {                
                Debug.Log("move l ");
                rigidbody.velocity = Vector2.left * Time.deltaTime * speed;
            }if (controlCode == ControlCode.MoveUp)
            {
                Debug.Log("move up ");
                rigidbody.velocity =Vector3.up * Time.deltaTime * speed;
            }if (controlCode == ControlCode.MoveDown)
            {
                Debug.Log("move down");
                rigidbody.velocity = Vector3.down * Time.deltaTime * speed;
            }
        }
        
    }
}