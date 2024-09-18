using System;
using Level.Props;
using Level.Specification;
using Utilities.Model;

namespace Level
{
    public class LevelModel : IModel
    {
        public event Action OnRoadCreate;
        public event Action<RoadView> OnRoadRemove;
        public event Action<RoadView> OnRoadFill;
        
        public readonly LevelSpecification Specification;
        public readonly PropsPullsCollection PropsPullsCollection = new();

        public LevelModel(LevelSpecification specification)
        {
            Specification = specification;
        }

        public void CreateRoadSegment()
        {
            OnRoadCreate?.Invoke();
        }

        public void RemoveRoadSegment(RoadView roadSegment)
        {
            OnRoadRemove?.Invoke(roadSegment);
        }

        public void FillRoadSegment(RoadView roadSegment)
        {
            OnRoadFill?.Invoke(roadSegment);
        }
    }
}