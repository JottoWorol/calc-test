using Core.Alerts;
using Core.Buttons.InputHandlers;
using Core.Calculator;
using Core.Notifications;
using UnityEngine;

namespace Core.Infrastructure
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private LifecycleContainer _lifecycleContainer;
        [SerializeField] private SceneData _sceneData;

        private void Awake()
        {
            ComposeDependencies();
        }

        private void ComposeDependencies()
        {
            var calculatorStateMachine = new CalculatorStateMachine();
            var textField = new TextField(_sceneData);
            var calculatorOutputHandler = new CalculatorOutputHandler(textField);
            var calculatorBrain = new CalculatorBrain(calculatorStateMachine, calculatorOutputHandler);
            var calculatorInput = new CalculatorInput(calculatorBrain, textField);

            var digitInputHandler = new DigitInputHandler(_sceneData, calculatorInput);
            var operatorInputHandler = new OperatorsInputHandler(_sceneData, calculatorInput);
            var confirmInputHandler = new ConfirmInputHandler(_sceneData, calculatorInput);
            var clearInputHandler = new ClearInputHandler(_sceneData, calculatorInput);
            var getResultInputHandler = new GetResultInputHandler(_sceneData, calculatorInput);

            var buttonInteractabilitySwitch = new ButtonsInteractabilitySwitch(calculatorStateMachine, _sceneData);
            var dataSave = new DataSave(calculatorBrain, textField, calculatorStateMachine);
            
            var notificationService = new NotificationService();
            var onZeroDivisionAlert = new OnZeroDivisionAlert(calculatorBrain, notificationService);

            _lifecycleContainer
                .Add(notificationService)
                .Add(digitInputHandler)
                .Add(operatorInputHandler)
                .Add(confirmInputHandler)
                .Add(clearInputHandler)
                .Add(getResultInputHandler)
                .Add(buttonInteractabilitySwitch)
                .Add(dataSave)
                .Add(onZeroDivisionAlert);
        }
    }
}