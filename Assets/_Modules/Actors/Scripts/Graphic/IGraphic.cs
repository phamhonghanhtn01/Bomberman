namespace Actors
{
    public interface IGraphic
    {
        bool IsInitialized { get; }
        void Initialize();
        void SetAlpha(float alpha);
    }
}