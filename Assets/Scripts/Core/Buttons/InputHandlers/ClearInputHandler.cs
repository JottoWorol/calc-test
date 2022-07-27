using Core.Calculator;
using Core.Infrastructure;

namespace Core.Buttons.InputHandlers
{
    public class ClearInputHandler : SingleButtonInputHandler
    {
        private readonly CalculatorInput _calculatorInput;

        public ClearInputHandler(SceneData sceneData, CalculatorInput calculatorInput)
        {
            _calculatorInput = calculatorInput;
            CalcButton = sceneData.CalculatorView.CancelButton;
        }

        protected override CalcButton CalcButton { get; }

        protected override void OnClicked(CalcButton button)
        {
            _calculatorInput.Clear();
        }
    }
}