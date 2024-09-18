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
        private const float RoadSpawnRate = 3f;
        private float _checkTimer;
        private float _spawnTimer;
        
        private readonly List<RoadView> _oldRoads = new();
        private bool _hasMissingRoads;
        
        public LevelGenerateRoadUpdater(ICarModel carModel, LevelModel levelModel, LevelPropPull pull, LevelSceneView sceneView)
        {
            _carModel = carModel;
            _levelModel = levelModel;
            _pull = pull;
            _sceneView = sceneView;
        }
        
        public void Update(float deltaTime)
        {
            _checkTimer += deltaTime;
            _spawnTimer += deltaTime;

            if (_checkTimer >= WaitCheckTime)
            {
                TryUpdateRoad();
                RemoveOldRoad();
                SpawnMissingRoad();
                
                _checkTimer = 0;
            }
        }

        private void SpawnMissingRoad()
        {
            var activeRoadElements = _sceneView.ActiveRoadElements;
            var delta = _pull.Description.MinActiveElementsCount - activeRoadElements.Count;
            
            if (_hasMissingRoads)
            {
                if (_spawnTimer >= RoadSpawnRate)
                {
                    _levelModel.CreateRoadSegment();
                    
                    delta--;
                    _spawnTimer = 0;
                }
            }

            _hasMissingRoads = delta > 0;
        }

        private void RemoveOldRoad()
        {
            foreach (var road in _oldRoads)
            {
                _levelModel.RemoveRoadSegment(road);
            }
            
            _oldRoads.Clear();
        }

        private void TryUpdateRoad()
        {
            foreach (var activeElement in _sceneView.ActiveRoadElements)     
            {
                if (activeElement.EndPoint.position.z + 200f < _carModel.CurrentPosition.Value.z)
                {
                    _oldRoads.Add(activeElement);
                }
            }
        }
    }
}