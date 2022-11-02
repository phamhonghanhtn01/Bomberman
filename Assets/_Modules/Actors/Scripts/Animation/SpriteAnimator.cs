
using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Actors
{
    public class SpriteAnimator :MonoBehaviour, IAnimator
    {
        [SerializeField] private Animator anim; 
        
        public bool IsInitialized { get; }

        public void Initialize()
        {
            
        }

       

        public void Play(string animationName)
        {
            anim.Play(animationName);
        }

        public void SetTimeScale(float timeScale)
        {
            
        }
    }
}