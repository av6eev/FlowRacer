using System.Collections.Generic;
using System.Linq;
using Level.Props;
using Level.Pull;
using Presenter;
using UnityEngine;

namespace Level.Generate.Trees
{
    public class LevelGenerateTreesPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private LevelPropPull _pull;

        public LevelGenerateTreesPresenter(IGameModel gameModel, LevelModel model)
        {
            _gameModel = gameModel;
            _model = model;
        }
        
        public void Init()
        {
            if (_model.PropsPullsCollection.TryGetPull(PropsType.Tree, out var treePull))
            {
                _pull = treePull;
            }
            else
            {
                return;
            }
            
            _model.OnRoadFill += CreateTrees;
            _model.OnRoadRemove += HandleRoadRemove;
        }

        public void Dispose()
        {
            _model.OnRoadFill -= CreateTrees;
            _model.OnRoadRemove -= HandleRoadRemove;
        }

        private void HandleRoadRemove(RoadView roadSegment)
        {
            var toRemoveList = new List<PropView>();

            foreach (var tree in roadSegment.ActiveProps.Where(element => element.Type == _pull.Description.Type))
            {
                _pull.Put(tree);
            }

            foreach (var prop in toRemoveList)
            {
                roadSegment.ActiveProps.Remove(prop);
            }
        }

        private void CreateTrees(RoadView roadSegment)
        {
            var pullDescription = _pull.Description;
            var randomCount = Random.Range(pullDescription.MinActiveElementsCount, pullDescription.MaxActiveElementsCount);

            for (var i = 0; i < randomCount; i++)
            {
                var tree = _pull.Get();
                var supposedPosition = LevelHelper.GetRandomPosition(roadSegment);
                var supposedRotation = LevelHelper.GetRandomRotation();
                
                if (LevelHelper.CheckOverlappingWithProps(tree, supposedPosition))
                {
                    _pull.Put(tree);
                    continue;
                }

                tree.transform.position = supposedPosition;
                tree.transform.rotation = Quaternion.Euler(supposedRotation);
                roadSegment.ActiveProps.Add(tree);
            }
        }
    }
}