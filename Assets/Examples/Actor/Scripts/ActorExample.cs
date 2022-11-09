using System;
using Actors;
using UnityEngine;

namespace Examples.Actors
{
    //null Object pattern: https://www.c-sharpcorner.com/article/null-object-design-pattern/
    public class ActorExample : MonoBehaviour
    {
        [SerializeField] private Actor actor;

        private void Start()
        {
            actor.Health.SetMaxHealth(15f);
            actor.Input.Initialize(actor);
        }
        
    }
}