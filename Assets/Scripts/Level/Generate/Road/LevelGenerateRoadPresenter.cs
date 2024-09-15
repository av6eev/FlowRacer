using System.Linq;
using GameScenes.Level;
using Level.Props;
using Level.Pull;
using Presenter;
using UnityEngine;

namespace Level.Generate.Road
{
    public class LevelGenerateRoadPresenter : IPresenter
    {
        private const int FirstActiveElements = 8;
        
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _view;
        
        private LevelPropPull _pull;
        

        public LevelGenerateRoadPresenter(IGameModel gameModel, LevelModel model, LevelSceneView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            if (_model.PropsPullsCollection.TryGetPull(PropsType.Road, out var roadPull))
            {
                _pull = roadPull;
            }
            else
            {
                return;
            }

            for (var i = 0; i < FirstActiveElements; i++)
            {
                var element = _pull.Get();

                var activeRoadElements = _view.ActiveRoadElements;
                activeRoadElements.Add(element);

                if (activeRoadElements.Count == 1)
                {
                    element.transform.position = new Vector3(0, 0, -18f);
                }
                else
                {
                    element.transform.position = activeRoadElements[i-1].EndPoint.position;
                }
                
                element.Show();
            }
        }

        public void Dispose()
        {
            _view.ActiveRoadElements.Clear();
        }
    }
}