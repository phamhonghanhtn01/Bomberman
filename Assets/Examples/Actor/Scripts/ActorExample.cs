using System;
using Actors;
using UnityEngine;

namespace Examples.Actors
{
    //null Object pattern: https://www.c-sharpcorner.com/article/null-object-design-pattern/
    public class ActorExample : MonoBehaviour
    {
        public VariableJoystick variableJoystick;

        [SerializeField] private Actor actor;

        private void Start()
        {
            actor.Health.SetMaxHealth(15f);
            
        }

        private void Update()
        {
            Debug.Log("V-H : " + variableJoystick.Vertical + " , " +  variableJoystick.Horizontal);
            actor.Input.SetDirection(variableJoystick.Vertical, variableJoystick.Horizontal);

        }
    }
}