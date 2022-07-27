using Core.Calculator;
using Core.Infrastructure;

namespace Core.Buttons.InputHandlers
{
    public class ConfirmInputHandler : SingleButtonInputHandler
    {
        private readonly CalculatorInput _calculatorInput;

        public ConfirmInputHandler(SceneData sceneData, CalculatorInput calculatorInput)
        {
            _calculatorInput = calculatorInput;
            CalcButton = sceneData.CalculatorView.ConfirmButton;
        }

        protected override CalcButton CalcButton { get; }

        protected override void OnClicked(CalcButton button)
        {
            _calculatorInput.Confirm();
        }
    }
}