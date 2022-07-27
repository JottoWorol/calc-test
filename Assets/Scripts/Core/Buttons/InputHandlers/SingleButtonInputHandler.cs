using Core.Infrastructure;

namespace Core.Buttons.InputHandlers
{
    public abstract class SingleButtonInputHandler : IStartable, IDestroyable
    {
        protected abstract CalcButton CalcButton { get; }

        public void OnStart()
        {
            CalcButton.Clicked += OnClicked;
        }

        public void OnDestroy()
        {
            CalcButton.Clicked -= OnClicked;
        }

        protected abstract void OnClicked(CalcButton button);
    }
}