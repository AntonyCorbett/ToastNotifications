using ToastNotifications.Core;

namespace CustomNotificationsExample.CustomInput;

public class CustomInputNotification : NotificationBase
{
    private CustomInputDisplayPart _displayPart;
    private string _inputText;

    public CustomInputNotification(string message, string initialText, MessageOptions messageOptions) 
        : base(message, messageOptions)
    {
        InputText = initialText;
    }

    public override NotificationDisplayPart DisplayPart => _displayPart ??= new CustomInputDisplayPart(this);

    public string InputText
    {
        get => _inputText;
        set
        {
            _inputText = value;
            OnPropertyChanged();
        }
    }
}