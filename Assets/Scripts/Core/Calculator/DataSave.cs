using System;
using Core.Infrastructure;
using UnityEngine;

namespace Core.Calculator
{
    public class DataSave : IStartable, IDestroyable
    {
        private readonly CalculatorBrain _calculatorBrain;
        private readonly CalculatorStateMachine _stateMachine;
        private readonly TextField _textField;
        
        public DataSave(CalculatorBrain calculatorBrain, TextField textField, CalculatorStateMachine stateMachine)
        {
            _calculatorBrain = calculatorBrain;
            _textField = textField;
            _stateMachine = stateMachine;
        }

        public void OnStart()
        {
            _stateMachine.StateChanged += OnStateChanged;
            _textField.Updated += OnTextFieldUpdated;
            
            RetrieveData();
        }

        public void OnDestroy()
        {
            _stateMachine.StateChanged -= OnStateChanged;
            _textField.Updated -= OnTextFieldUpdated;
        }

        private void OnTextFieldUpdated()
        {
            SaveData();
        }

        private void OnStateChanged()
        {
            SaveData();
        }

        private void SaveData()
        {
            var data = new CalculatorData
            {
                _brainState = _calculatorBrain.GetCurrentState(),
                _text = _textField.GetText(),
                _stateIndex = (int)_stateMachine.State,
            };

            SaveDataString = JsonUtility.ToJson(data);
        }

        private void RetrieveData()
        {
            if (SaveDataString == "")
                return;
            
            var data = JsonUtility.FromJson<CalculatorData>(SaveDataString);
            _calculatorBrain.SetState(data._brainState);
            _textField.SetText(data._text);
            _stateMachine.SetState((StateEnum)data._stateIndex);
        }

        private const string SaveDataStringKey = nameof(SaveDataString);

        public string SaveDataString
        {
            get => PlayerPrefs.GetString(SaveDataStringKey, "");
            private set => PlayerPrefs.SetString(SaveDataStringKey, value);
        }
    }

    [Serializable]
    public class CalculatorData
    {
        [SerializeField] public int _stateIndex;
        [SerializeField] public CalculatorBrain.BrainState _brainState;
        [SerializeField] public string _text;
    }
}