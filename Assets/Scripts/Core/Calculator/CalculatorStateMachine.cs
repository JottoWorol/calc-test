using System;

namespace Core.Calculator
{
    public class CalculatorStateMachine
    {
        public StateEnum State { get; private set; } = StateEnum.PreOperand1;

        public event Action StateChanged;
        
        public void SetState(StateEnum stateEnum)
        {
            State = stateEnum;
            StateChanged?.Invoke();
        }
    }
}