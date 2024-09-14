using Reactive.Event;
using Reactive.Field;

namespace Input
{
    public class InputModel : IInputModel
    {
        public ReactiveEvent OnDebugPanelToggle { get; } = new();

        public ReactiveField<bool> IsEnable { get; } = new(true);

        public void Enable()
        {
            IsEnable.Value = true;
        }

        public void Disable()
        {
            IsEnable.Value = false;
        }
    }
}