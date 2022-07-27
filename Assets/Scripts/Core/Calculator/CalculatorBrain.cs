using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Calculator
{
    public class CalculatorBrain
    {
        private readonly CalculatorStateMachine _calculatorStateMachine;
        private readonly CalculatorOutputHandler _calculatorOutputHandler;

        public CalculatorBrain(CalculatorStateMachine calculatorStateMachine, CalculatorOutputHandler calculatorOutputHandler)
        {
            _calculatorStateMachine = calculatorStateMachine;
            _calculatorOutputHandler = calculatorOutputHandler;
        }
        
        private List<int> _operandDigits = new List<int>();
        
        private float _operand1;
        private float _operand2;
        private OperatorType _operator;
        
        public event Action ZeroDivisionError;
        
        public void AddDigit(int digit)
        {
            _operandDigits.Add(digit);
            
            if(_calculatorStateMachine.State == StateEnum.PreOperand1)
                _calculatorStateMachine.SetState(StateEnum.Operand1);
            
            if(_calculatorStateMachine.State == StateEnum.PreOperand2)
                _calculatorStateMachine.SetState(StateEnum.Operand2);
        }
        
        private float GetNumberFromDigits()
        {
            var number = 0;
            for (var digitIndex = 0; digitIndex < _operandDigits.Count; digitIndex++)
            {
                number += _operandDigits[digitIndex] * (int) Mathf.Pow(10, _operandDigits.Count - digitIndex - 1);
            }

            return number;
        }

        public void ConfirmNumber()
        {
            if (_calculatorStateMachine.State == StateEnum.Operand1)
            {
                _operand1 = GetNumberFromDigits();
                _operandDigits.Clear();
                
                _calculatorStateMachine.SetState(StateEnum.Operator);
                return;
            }
            
            if (_calculatorStateMachine.State == StateEnum.Operand2)
            {
                _operand2 = GetNumberFromDigits();
                _operandDigits.Clear();
                
                _calculatorStateMachine.SetState(StateEnum.ReadyToCalculate);
                return;
            }
        }

        public void SetOperator(OperatorType operatorType)
        {
            _operator = operatorType;
            _calculatorStateMachine.SetState(StateEnum.PreOperand2);
        }

        public void GetResult()
        {
            
            if (_operator == OperatorType.Divide && _operand2 == 0)
            {
                _calculatorStateMachine.SetState(StateEnum.Result);

                ZeroDivisionError?.Invoke();
                return;
            }
            
            var result = _operator switch
            {
                OperatorType.Plus => _operand1 + _operand2,
                OperatorType.Minus => _operand1 - _operand2,
                OperatorType.Multiply => _operand1 * _operand2,
                OperatorType.Divide => _operand1 / _operand2,
                _ => throw new ArgumentOutOfRangeException(),
            };

            _calculatorOutputHandler.AddOutput(result);
            _calculatorStateMachine.SetState(StateEnum.Result);
        }

        public void ShowPremiumZeroDivisionResult()
        {
            if (_operand1 > 0)
            {
                _calculatorOutputHandler.AddPositiveZeroOutput();
            }
            else
            {
                _calculatorOutputHandler.AddZeroZeroOutput();
            }
        }

        public void Reset()
        {
            _calculatorStateMachine.SetState(StateEnum.PreOperand1);
            _operandDigits.Clear();
            _operand1 = 0;
            _operand2 = 0;
        }

        public BrainState GetCurrentState()
        {
            return new BrainState(_operand1, _operand2, _operator, _operandDigits);
        }
        
        public void SetState(BrainState brainState)
        {
            _operand1 = brainState.Operand1;
            _operand2 = brainState.Operand2;
            _operator = brainState.Operator;
            _operandDigits = brainState.OperandDigits;
        }
        
        [Serializable]
        public struct BrainState
        {
            public float Operand1;
            public float Operand2;
            public OperatorType Operator;
            public List<int> OperandDigits;
            
            public BrainState(float operand1, float operand2, OperatorType operatorType, List<int> digits)
            {
                Operand1 = operand1;
                Operand2 = operand2;
                Operator = operatorType;
                OperandDigits = digits;
            }
        }
    }
}