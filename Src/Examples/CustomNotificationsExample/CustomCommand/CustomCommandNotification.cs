using CustomNotificationsExample.Utilities;
using System;
using System.Windows.Input;
using ToastNotifications.Core;

namespace CustomNotificationsExample.CustomCommand;

public class CustomCommandNotification : NotificationBase
{
    private CustomCommandDisplayPart _displayPart;

    private readonly Action<CustomCommandNotification> _confirmAction;
    private readonly Action<CustomCommandNotification> _declineAction;

    public ICommand ConfirmCommand { get; set; }
    public ICommand DeclineCommand { get; set; }

    public CustomCommandNotification(string message, 
        Action<CustomCommandNotification> confirmAction, 
        Action<CustomCommandNotification> declineAction, 
        MessageOptions messageOptions) 
        : base(message, messageOptions)
    {
        _confirmAction = confirmAction;
        _declineAction = declineAction;

        ConfirmCommand = new RelayCommand(x => _confirmAction(this));
        DeclineCommand = new RelayCommand(x => _declineAction(this));
    }

    public override NotificationDisplayPart DisplayPart => _displayPart ??= new CustomCommandDisplayPart(this);
}