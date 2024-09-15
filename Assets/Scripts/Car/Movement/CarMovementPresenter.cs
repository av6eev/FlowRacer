using Presenter;

namespace Car.Movement
{
    public class CarMovementPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly CarModel _model;
        private readonly CarView _view;

        public CarMovementPresenter(IGameModel gameModel, CarModel model, CarView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            
        }

        public void Dispose()
        {
        }
    }
}