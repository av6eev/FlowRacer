using GameScenes.Level;
using Level.Generate.Road;
using Level.Props;
using Presenter;

namespace Level.Generate
{
    public class LevelGeneratePresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelSceneView _view;

        private readonly PresentersList _presenters = new();
        
        public LevelGeneratePresenter(IGameModel gameModel, LevelModel model, LevelSceneView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public async void Init()
        {
            var pullsCollection = _model.PropsPullsCollection;
            
            foreach (var pullDescription in _model.Specification.Pulls)
            {
                pullsCollection.Add(pullDescription);
            }

            pullsCollection.InitAll();
            await pullsCollection.IsInitialized;
            
            _presenters.Add(new LevelGenerateRoadPresenter(_gameModel, _model, _view));
            
            _presenters.Init();
        }

        public void Dispose()
        {
            _presenters.Dispose();
            _presenters.Clear();
            
            _model.PropsPullsCollection.DisposeAll();
        }
    }
}