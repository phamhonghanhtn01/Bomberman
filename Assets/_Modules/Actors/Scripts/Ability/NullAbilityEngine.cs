namespace Actors
{
    public class NullAbilityEngine : IAbilityEngine
    {
        public static readonly NullAbilityEngine Instance = new NullAbilityEngine();

        private NullAbilityEngine()
        {
            
        }
    }
}