using System.Collections.Generic;

namespace Core.Calculator
{
    public class CalculatorInput
    {
        private readonly CalculatorBrain _calculatorBrain;
        private readonly TextField _textField;

        private readonly Dictionary<OperatorType, char> _operatorSymbols = new Dictionary<OperatorType, char>()
        {
            { OperatorType.Plus, '+' },
            {OperatorType.Minus, '-'},
            {OperatorType.Multiply, '*'},
            {OperatorType.Divide, '/'},
        };

        public CalculatorInput(CalculatorBrain calculatorBrain, TextField textField)
        {
            _calculatorBrain = calculatorBrain;
            _textField = textField;
        }

        public void InputDigit(int digit)
        {
            _calculatorBrain.AddDigit(digit);
            _textField.Append(digit);
        }

        public void Confirm()
        {
            _calculatorBrain.ConfirmNumber();
        }

        public void Clear()
        {
            _calculatorBrain.Reset();
            _textField.Clear();
        }

        public void GetResult()
        {
            _textField.Append('=');
            _calculatorBrain.GetResult();
        }
        
        public void Operator(OperatorType operatorType)
        {
            _calculatorBrain.SetOperator(operatorType);
            _textField.Append(_operatorSymbols[operatorType]);
        }
    }
}