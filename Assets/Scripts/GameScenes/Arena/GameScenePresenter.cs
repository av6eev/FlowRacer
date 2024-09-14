using SceneManagement;

namespace GameScenes.Arena
{
    public class GameScenePresenter : BaseGameScenePresenter
    {
        private readonly GameModel _gameModel;
        private readonly GameSceneView _view;
        
        public GameScenePresenter(GameModel gameModel, GameSceneView view) : base(gameModel, view)
        {
            _gameModel = gameModel;
            _view = view;
        }

        protected override void AfterInit()
        {
            _gameModel.SceneManagementModelsCollection.SetCurrentSceneId(SceneConst.Game);
        }

        protected override void AfterDispose()
        {
        }
    }
}