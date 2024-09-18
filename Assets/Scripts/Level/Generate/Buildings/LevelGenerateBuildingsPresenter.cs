using System.Collections.Generic;
using System.Linq;
using Level.Props;
using Level.Pull;
using Presenter;
using UnityEngine;

namespace Level.Generate.Buildings
{
    public class LevelGenerateBuildingsPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private  LevelPropPull _pull;

        public LevelGenerateBuildingsPresenter(IGameModel gameModel, LevelModel model)
        {
            _gameModel = gameModel;
            _model = model;
        }
        
        public void Init()
        {
            if (_model.PropsPullsCollection.TryGetPull(PropsType.Building, out var buildingsPull))
            {
                _pull = buildingsPull;
            }
            else
            {
                return;
            }
            
            _model.OnRoadFill += CreateBuildings;
            _model.OnRoadRemove += HandleRoadRemove;
        }

        public void Dispose()
        {
            _model.OnRoadFill -= CreateBuildings;
            _model.OnRoadRemove -= HandleRoadRemove;
        }

        private void HandleRoadRemove(RoadView roadSegment)
        {
            var toRemoveList = new List<PropView>();
            
            foreach (var building in roadSegment.ActiveProps.Where(element => element.Type == _pull.Description.Type))
            {
                _pull.Put(building);
                toRemoveList.Add(building);
            }

            foreach (var prop in toRemoveList)
            {
                roadSegment.ActiveProps.Remove(prop);
            }
        }

        private void CreateBuildings(RoadView roadSegment)
        {
            var pullDescription = _pull.Description;
            var randomCount = Random.Range(pullDescription.MinActiveElementsCount, pullDescription.MaxActiveElementsCount);

            for (var i = 0; i < randomCount; i++)
            {
                var building = _pull.Get();
                var supposedPosition = LevelHelper.GetRandomPosition(roadSegment);
                var supposedRotation = LevelHelper.GetRandomRotation();
                
                if (LevelHelper.CheckOverlappingWithProps(building, supposedPosition))
                {
                    _pull.Put(building);
                    continue;
                }

                building.transform.position = supposedPosition;
                building.transform.rotation = Quaternion.Euler(supposedRotation);
                roadSegment.ActiveProps.Add(building);
            }
        }
    }
}