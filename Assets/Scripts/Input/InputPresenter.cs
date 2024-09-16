using Presenter;
using UnityEngine;

namespace Input
{
    public class InputPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly InputModel _model;
        private readonly InputView _view;

        public InputPresenter(IGameModel gameModel, InputModel model, InputView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }

        public void Init()
        {
            _view.Initialize();

            _model.IsEnable.OnChanged += HandleStateChange;

            _view.OnTurnPerformed += HandleTurnPerformed;
            _view.OnTurnCanceled += HandleTurnCanceled;
        }

        public void Dispose()
        {
            _view.Dispose();
            
            _model.IsEnable.OnChanged -= HandleStateChange;
            
            _view.OnTurnPerformed -= HandleTurnPerformed;
            _view.OnTurnCanceled -= HandleTurnCanceled;
        }

        private void HandleTurnCanceled()
        {
            _model.TurnInput = 0f;
        }

        private void HandleTurnPerformed(float value)
        {
            _model.TurnInput = value;
        }

        private void HandleStateChange(bool newValue, bool oldValue)
        {
            var playerActionMap = _view.PlayerInputAsset.FindActionMap("Player");

            switch (newValue)
            {
                case true:
                    playerActionMap.Enable();
                    break;
                default:
                    playerActionMap.Disable();
                    break;
            }
        }
    }
}