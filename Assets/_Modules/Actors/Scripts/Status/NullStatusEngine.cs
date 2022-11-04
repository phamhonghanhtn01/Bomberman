using Statuses;

namespace Actors
{
    public class NullStatusEngine :IStatusEngine
    {
        public static readonly NullStatusEngine Instance = new NullStatusEngine();

        private NullStatusEngine()
        {
            
        }
        
        public bool IsLocked { get; set; }
        public void Initialize(Actor actor)
        {
            
        }

        public void AddStatus(BaseStatus status)
        {
            
        }

        public void RemoveStatus(BaseStatus status)
        {
            
        }

        public void ClearStatuses()
        {
            
        }
    }
}