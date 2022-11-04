namespace Actors
{
    public class NullMovement : IMovement
    {
        public static readonly NullMovement Instance = new NullMovement();

        private NullMovement()
        {
            
        }
        
        public void Move()
        {
            
        }
    }
}