using Presenter;
using Updater;

namespace Car.Movement
{
    public class CarMovementPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly CarModel _model;
        private readonly CarView _view;

        private IUpdater _movementUpdater;
        
        public CarMovementPresenter(IGameModel gameModel, CarModel model, CarView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _movementUpdater = new CarMovementUpdater(_gameModel.InputModel, _model, _view);
            _gameModel.FixedUpdatersList.Add(_movementUpdater);

            _model.IsReady = true;
        }

        public void Dispose()
        {
            _gameModel.FixedUpdatersList.Remove(_movementUpdater);
        }
    }
}