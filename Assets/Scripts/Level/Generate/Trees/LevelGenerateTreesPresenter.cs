using Level.Pull;
using Presenter;

namespace Level.Generate.Trees
{
    public class LevelGenerateTreesPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly LevelModel _model;
        private readonly LevelPropPull _pull;

        public LevelGenerateTreesPresenter(IGameModel gameModel, LevelModel model, LevelPropPull pull)
        {
            _gameModel = gameModel;
            _model = model;
            _pull = pull;
        }
        
        public void Init()
        {
            
        }

        public void Dispose()
        {
        }
    }
}