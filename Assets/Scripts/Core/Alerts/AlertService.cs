using System;
using Nrjwolf.Tools.AndroidEasyAlerts;

namespace Core.Alerts
{
    public static class AlertService
    {
        public static void ShowAlert(string title, string content, string positiveButton, string negativeButton,
            Action onPositiveAction, Action onNegativeAction)
        {
            AndroidEasyAlerts.ShowAlert(title, content,
                new AlertButton(negativeButton, onNegativeAction.Invoke, ButtonStyle.NEGATIVE),
                new AlertButton(positiveButton, onPositiveAction.Invoke, ButtonStyle.POSITIVE)
            );
        }
    }
}