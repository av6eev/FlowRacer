using GameScenes.UI.DebugPanel;
using GameScenes.UI.EnterNicknamePanel;
using LoadingScreen;
using LocationBuilder;

namespace GameScenes.UI
{
    public class UiSceneView : LocationSceneView
    {
        public DebugPanelView DebugPanelView;
        public LoadingScreenView LoadingScreenView;
        public EnterNicknamePanelView EnterNicknamePanelView;
    }
}