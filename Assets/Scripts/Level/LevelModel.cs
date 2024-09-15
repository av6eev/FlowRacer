using Level.Props;
using Level.Specification;
using Utilities.Model;

namespace Level
{
    public class LevelModel : IModel
    {
        public readonly LevelSpecification Specification;
        public readonly PropsPullsCollection PropsPullsCollection = new();

        public LevelModel(LevelSpecification specification)
        {
            Specification = specification;
        }
    }
}