using Core.Calculator;
using UnityEngine;

namespace Core.Infrastructure
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private CalculatorView _calculatorView;

        public CalculatorView CalculatorView => _calculatorView;
    }
}