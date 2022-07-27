using System.Collections.Generic;
using Core.Calculator;
using Core.Infrastructure;

namespace Core.Buttons.InputHandlers
{
    public class DigitInputHandler : IDestroyable
    {
        private readonly CalculatorInput _calculatorInput;
        private readonly Dictionary<CalcButton, int> _buttonToIndex = new Dictionary<CalcButton, int>();

        public DigitInputHandler(SceneData sceneData, CalculatorInput calculatorInput)
        {
            _calculatorInput = calculatorInput;
            
            for (var index = 0; index < sceneData.CalculatorView.NumericButtons.Length; index++)
            {
                var button = sceneData.CalculatorView.NumericButtons[index];
                _buttonToIndex[button] = index;
                button.Clicked += OnButtonClicked;
            }
        }

        private void OnButtonClicked(CalcButton button)
        {
            _calculatorInput.InputDigit(_buttonToIndex[button]);
        }

        public void OnDestroy()
        {
            foreach (var button in _buttonToIndex.Keys)
            {
                button.Clicked -= OnButtonClicked;
            }
        }
    }
}