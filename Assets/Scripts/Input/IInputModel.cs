using Reactive.Event;

namespace Input
{
    public interface IInputModel
    {
        ReactiveEvent OnDebugPanelToggle { get; }
        void Enable();
        void Disable();
    }
}