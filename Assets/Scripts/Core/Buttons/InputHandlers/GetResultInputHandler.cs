using Core.Calculator;
using Core.Infrastructure;

namespace Core.Buttons.InputHandlers
{
    public class GetResultInputHandler : SingleButtonInputHandler
    {
        private readonly CalculatorInput _calculatorInput;

        public GetResultInputHandler(SceneData sceneData, CalculatorInput calculatorInput)
        {
            _calculatorInput = calculatorInput;
            CalcButton = sceneData.CalculatorView.GetResultButton;
        }

        protected override CalcButton CalcButton { get; }

        protected override void OnClicked(CalcButton button)
        {
            _calculatorInput.GetResult();
        }
    }
}