using System;
using System.Text;
using Core.Infrastructure;

namespace Core.Calculator
{
    public class TextField
    {
        private readonly CalculatorView _calculatorView;
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        public TextField(SceneData sceneData) => _calculatorView = sceneData.CalculatorView;

        public event Action Updated; 

        public void Append(char symbol)
        {
            _stringBuilder.Append(symbol);
            UpdateView();
        }

        public void Append(string text)
        {
            _stringBuilder.Append(text);
            UpdateView();
        }

        public void Append(int number)
        {
            _stringBuilder.Append(number);
            UpdateView();
        }

        public void Append(float number)
        {
            _stringBuilder.Append(number);
            UpdateView();
        }

        public void Clear()
        {
            _stringBuilder.Clear();
            UpdateView();
        }
        
        public string GetText() => _stringBuilder.ToString();
        public string SetText(string text)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(text);
            UpdateView();
            return text;
        }

        private void UpdateView()
        {
            _calculatorView.TextField.SetText(_stringBuilder);
            Updated?.Invoke();
        }
    }
}