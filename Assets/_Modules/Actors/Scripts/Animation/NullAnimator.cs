namespace Actors
{
    public class NullAnimator : IAnimator
    {
        public static readonly NullAnimator Instance = new NullAnimator();

        private NullAnimator()
        {
            
        }
        
        public bool IsInitialized { get; }
        
        public void Initialize()
        {
            
        }

        public void Play(string animationName)
        {
            
        }

        public void SetTimeScale(float timeScale)
        {
            
        }
    }
}