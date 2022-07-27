using Core.Buttons;
using TMPro;
using UnityEngine;

namespace Core.Calculator
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private CalcButton[] _numericButtons;
        
        [SerializeField] private CalcButton _confirmButton;
        [SerializeField] private CalcButton _cancelButton;
        [SerializeField] private CalcButton _getResultButton;
        
        [SerializeField] private CalcButton _plusButton;
        [SerializeField] private CalcButton _minusButton;
        [SerializeField] private CalcButton _multiplyButton;
        [SerializeField] private CalcButton _divideButton;

        [SerializeField] private TMP_Text _textField;

        public CalcButton[] NumericButtons => _numericButtons;
        public CalcButton ConfirmButton => _confirmButton;
        public CalcButton CancelButton => _cancelButton;
        public CalcButton GetResultButton => _getResultButton;
        public CalcButton PlusButton => _plusButton;
        public CalcButton MinusButton => _minusButton;
        public CalcButton MultiplyButton => _multiplyButton;
        public CalcButton DivideButton => _divideButton;
        public TMP_Text TextField => _textField;
    }
}