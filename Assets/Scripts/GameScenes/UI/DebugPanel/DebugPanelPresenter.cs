using DebugUI;
using Presenter;

namespace GameScenes.UI.DebugPanel
{
    public class DebugPanelPresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly DebugPanelModel _model;
        private readonly DebugPanelView _view;

        public DebugPanelPresenter(IGameModel gameModel, DebugPanelModel model, DebugPanelView view)
        {
            _gameModel = gameModel;
            _model = model;
            _view = view;
        }
        
        public void Init()
        {
            _view.gameObject.SetActive(false);
            
            _gameModel.InputModel.OnDebugPanelToggle.OnChanged += HandleDebugPanelToggle;
        }

        public void Dispose()
        {
            _gameModel.InputModel.OnDebugPanelToggle.OnChanged -= HandleDebugPanelToggle;
        }

        private void HandleDebugPanelToggle()
        {
            _model.IsOpen = !_model.IsOpen;

            switch (_model.IsOpen)
            {
                case true:
                    _view.gameObject.SetActive(true);
                    
                    ConfigureBuilder();
                    break;
                case false:
                    _view.gameObject.SetActive(false);
                    break;
            }
        }

        private void ConfigureBuilder()
        {
            var builder = new DebugUIBuilder();

            builder.ConfigureWindowOptions(options =>
            {
                options.Title = "Debug Panel";
                options.Draggable = true;
            });

            builder.BuildWith(_view.UIDocument);
        }
    }
}