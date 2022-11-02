using Statuses;

namespace Actors
{
    public interface IStatusEngine
    {
        bool IsLocked { set; get; }
        void Initialize(Actor actor);
        void AddStatus(BaseStatus status);
        void RemoveStatus(BaseStatus status);
        void ClearStatuses();
    }
}