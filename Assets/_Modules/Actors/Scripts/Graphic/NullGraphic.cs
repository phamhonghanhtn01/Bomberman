namespace Actors
{
    public class NullGraphic : IGraphic
    {
        public static readonly NullGraphic Instance = new NullGraphic();

        private NullGraphic()
        {
            
        }
        public bool IsInitialized { get; }
        
        public void Initialize()
        {
            
        }

        public void SetAlpha(float alpha)
        {
            
        }
    }
}