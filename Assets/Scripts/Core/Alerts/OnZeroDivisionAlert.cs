using Core.Calculator;
using Core.Infrastructure;
using Core.Notifications;

namespace Core.Alerts
{
    public class OnZeroDivisionAlert : IStartable, IDestroyable
    {
        private const string Title = "Zero Division";
        private const string Message = "Get Premium to unlock this feature";
        private const string PositiveButton = "Get Premium";
        private const string NegativeButton = "Cancel";

        private readonly CalculatorBrain _calculatorBrain;
        private readonly NotificationService _notificationService;

        public OnZeroDivisionAlert(CalculatorBrain calculatorBrain, NotificationService notificationService)
        {
            _calculatorBrain = calculatorBrain;
            _notificationService = notificationService;
        }

        public void OnDestroy()
        {
            _calculatorBrain.ZeroDivisionError -= SendAlert;
        }

        public void OnStart()
        {
            _calculatorBrain.ZeroDivisionError += SendAlert;
        }

        private void SendAlert()
        {
            AlertService.ShowAlert(Title, Message, PositiveButton, NegativeButton,
                OnPositiveButtonClicked, OnNegativeButtonClicked
            );
        }
        
        private void OnPositiveButtonClicked()
        {
            _calculatorBrain.ShowPremiumZeroDivisionResult();
        }
        
        private void OnNegativeButtonClicked()
        {
            _notificationService.SendNotification("Premium", "No money - no honey");
        }
    }
}