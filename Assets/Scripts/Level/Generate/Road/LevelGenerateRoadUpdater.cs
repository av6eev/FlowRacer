using System.Collections.Generic;
using Car;
using GameScenes.Level;
using Level.Props;
using Level.Pull;
using Updater;

namespace Level.Generate.Road
{
    public class LevelGenerateRoadUpdater : IUpdater
    {
        private readonly ICarModel _carModel;
        private readonly LevelModel _levelModel;
        private readonly LevelPropPull _pull;
        private readonly LevelSceneView _sceneView;

        private const float WaitCheckTime = .1f;
        private float _timer;

        private readonly List<PropView> _oldRoads = new();
        
        public LevelGenerateRoadUpdater(ICarModel carModel, LevelModel levelModel, LevelPropPull pull, LevelSceneView sceneView)
        {
            _carModel = carModel;
            _levelModel = levelModel;
            _pull = pull;
            _sceneView = sceneView;
        }
        
        public void Update(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer >= WaitCheckTime)
            {
                TryUpdateRoad();
                RemoveOldRoad();
                SpawnMissingRoad();
                
                _timer = 0;
            }
        }

        private void SpawnMissingRoad()
        {
            var activeRoadElements = _sceneView.ActiveRoadElements;
            var delta = _pull.Description.MinActiveElementsCount - activeRoadElements.Count;
            
            if (delta > 0)
            {
                for (var i = 0; i < delta; i++)
                {
                    var element = _pull.Get();
                    element.transform.position = activeRoadElements[^2].EndPoint.position;
                    
                    activeRoadElements.Add(element);
                }
            }
        }

        private void RemoveOldRoad()
        {
            foreach (var road in _oldRoads)
            {
                _sceneView.ActiveRoadElements.Remove(road);
                _pull.Put(road);
            }
            
            _oldRoads.Clear();
        }

        private void TryUpdateRoad()
        {
            foreach (var activeElement in _sceneView.ActiveRoadElements)     
            {
                if (activeElement.EndPoint.position.z + 30f < _carModel.CurrentPosition.Value.z)
                {
                    _oldRoads.Add(activeElement);
                }
            }
        }
    }
}