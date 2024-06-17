using ToastNotifications.Core;
using ToastNotifications.Messages.Warning;

namespace ToastNotifications.Messages;

public static class WarningExtensions
{
    public static void ShowWarning(this Notifier notifier, string message)
    {
        notifier.Notify(() => new WarningMessage(message));
    }

    public static void ShowWarning(this Notifier notifier, string message, MessageOptions displayOptions)
    {
        notifier.Notify(() => new WarningMessage(message, displayOptions));
    }
}