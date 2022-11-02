using System;
using Actors;
using UnityEngine;

namespace Examples.Actors
{
    public class ActorExample : MonoBehaviour
    {
        [SerializeField] private Actor actor;

        private void Start()
        {
            // actor.Health.Initialize(1000);
            // actor.Health.SetMaxHealth(1000);
            // actor.Health.SetMinHealth(1);
            // actor.Health.Damage(800);
            // Debug.Log(actor.Health.CurrentHealth);
            // actor.Animator.Initialize();
            
            
           actor.Animator.Play("upBomber");
           actor.Animator.Play("idleUp");

           actor.Animator.Play("leftBomber");
           actor.Animator.Play("idleLeft");

            
            
        }
    }
}