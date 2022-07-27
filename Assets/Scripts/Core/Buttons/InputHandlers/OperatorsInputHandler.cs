using Core.Calculator;
using Core.Infrastructure;

namespace Core.Buttons.InputHandlers
{
    public class OperatorsInputHandler : IStartable, IDestroyable
    {
        private readonly CalcButton _plusButton;
        private readonly CalcButton _minusButton;
        private readonly CalcButton _multiplyButton;
        private readonly CalcButton _divideButton;
        private readonly CalculatorInput _calculatorInput;
        
        public OperatorsInputHandler(SceneData sceneData, CalculatorInput calculatorInput)
        {
            _calculatorInput = calculatorInput;
            _plusButton = sceneData.CalculatorView.PlusButton;
            _minusButton = sceneData.CalculatorView.MinusButton;
            _multiplyButton = sceneData.CalculatorView.MultiplyButton;
            _divideButton = sceneData.CalculatorView.DivideButton;
        }
        
        public void OnStart()
        {
            _plusButton.Clicked += OnPlusButtonClick;
            _minusButton.Clicked += OnMinusButtonClick;
            _multiplyButton.Clicked += OnMultiplyButtonClick;
            _divideButton.Clicked += OnDivideButtonClick;
        }

        public void OnDestroy()
        {
            _plusButton.Clicked -= OnPlusButtonClick;
            _minusButton.Clicked -= OnMinusButtonClick;
            _multiplyButton.Clicked -= OnMultiplyButtonClick;
            _divideButton.Clicked -= OnDivideButtonClick;
        }

        private void OnPlusButtonClick(CalcButton obj)
        {
            _calculatorInput.Operator(OperatorType.Plus);
        }

        private void OnMinusButtonClick(CalcButton obj)
        {
            _calculatorInput.Operator(OperatorType.Minus);
        }

        private void OnMultiplyButtonClick(CalcButton obj)
        {
            _calculatorInput.Operator(OperatorType.Multiply);
        }

        private void OnDivideButtonClick(CalcButton obj)
        {
            _calculatorInput.Operator(OperatorType.Divide);
        }
    }
}