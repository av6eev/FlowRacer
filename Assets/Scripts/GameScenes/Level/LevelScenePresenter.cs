using Car;
using Level;
using Level.Generate;
using LoadingScreen;
using SceneManagement;

namespace GameScenes.Level
{
    public class LevelScenePresenter : BaseGameScenePresenter
    {
        private readonly GameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _view;

        public LevelScenePresenter(GameModel gameModel, LevelModel model, LevelSceneView view) : base(gameModel, view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }

        protected override void AfterInit()
        {
            _gameModel.SceneManagementModelsCollection.SetCurrentSceneId(SceneConst.Level);

            _gameModel.CarModel = new CarModel(_gameModel.Specifications.CarSpecifications["red"]);
            
            Presenters.Add(LoadingScreenMessageConst.GenerateLevel, new LevelGeneratePresenter(_gameModel, _model, _view));
            Presenters.Add(LoadingScreenMessageConst.Car, new CarPresenter(_gameModel, (CarModel)_gameModel.CarModel, _view));
        }

        protected override void AfterDispose()
        {
        }
    }
}