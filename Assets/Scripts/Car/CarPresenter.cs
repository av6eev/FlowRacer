using Car.Movement;
using GameScenes.Level;
using Loader.Object;
using Presenter;
using UnityEngine;

namespace Car
{
    public class CarPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly CarModel _model;
        private readonly LevelSceneView _levelSceneView;
        
        private CarView _view;
        private ILoadObjectModel<GameObject> _loadObjectModel;
        
        private readonly PresentersList _presenters = new();

        public CarPresenter(IGameModel gameModel, CarModel model, LevelSceneView levelSceneView)
        {
            _gameModel = gameModel;
            _model = model;
            _levelSceneView = levelSceneView;
        }
        
        public async void Init()
        {
            _loadObjectModel = _gameModel.LoadObjectsModel.Load<GameObject>(_model.Specification.PrefabId);
            await _loadObjectModel.LoadAwaiter;

            var component = _loadObjectModel.Result.GetComponent<CarView>();
            _view = Object.Instantiate(component, _levelSceneView.LevelRoot);
            _view.transform.position = new Vector3(0, 0, 0);
            
            _presenters.Add(new CarMovementPresenter(_gameModel, _model, _view));
            _presenters.Init();
        }

        public void Dispose()
        {
            _presenters.Dispose();
            _presenters.Clear();
        }
    }
}