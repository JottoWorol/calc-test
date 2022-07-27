using Core.Infrastructure;

namespace Core.Calculator
{
    public class ButtonsInteractabilitySwitch : IStartable, IDestroyable
    {
        private readonly CalculatorStateMachine _calculatorStateMachine;
        private readonly CalculatorView _calculatorView;

        public ButtonsInteractabilitySwitch(CalculatorStateMachine calculatorStateMachine, SceneData sceneData)
        {
            _calculatorStateMachine = calculatorStateMachine;
            _calculatorView = sceneData.CalculatorView;
        }

        public void OnDestroy()
        {
            _calculatorStateMachine.StateChanged -= OnStateChanged;
        }

        public void OnStart()
        {
            _calculatorStateMachine.StateChanged += OnStateChanged;
            OnStateChanged();
        }

        private void OnStateChanged()
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            var state = _calculatorStateMachine.State;

            var numeric = state == StateEnum.PreOperand1 || state == StateEnum.PreOperand2 ||
                          state == StateEnum.Operand1 || state == StateEnum.Operand2;
            var confirm = state == StateEnum.Operand1 || state == StateEnum.Operand2;
            var cancel = state == StateEnum.Result;
            var getResult = state == StateEnum.ReadyToCalculate;
            var operators = state == StateEnum.Operator;

            foreach (var button in _calculatorView.NumericButtons)
            {
                button.SetInteractable(numeric);
            }

            _calculatorView.ConfirmButton.SetInteractable(confirm);
            _calculatorView.CancelButton.SetInteractable(cancel);
            _calculatorView.GetResultButton.SetInteractable(getResult);

            _calculatorView.PlusButton.SetInteractable(operators);
            _calculatorView.MinusButton.SetInteractable(operators);
            _calculatorView.MultiplyButton.SetInteractable(operators);
            _calculatorView.DivideButton.SetInteractable(operators);
        }
    }
}