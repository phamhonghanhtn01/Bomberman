namespace Actors
{
    public interface IAnimator
    {
        bool IsInitialized { get; }
        void Initialize();
        void Play(string animationName);
        void SetTimeScale(float timeScale);
    }
}