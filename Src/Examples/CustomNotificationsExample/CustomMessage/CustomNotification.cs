using ToastNotifications.Core;

namespace CustomNotificationsExample.CustomMessage;

public class CustomNotification : NotificationBase
{
    private CustomDisplayPart _displayPart;
    private string _title;

    public override NotificationDisplayPart DisplayPart => _displayPart ??= new CustomDisplayPart(this);

    public CustomNotification(string title, string message, MessageOptions messageOptions) 
        : base(message, messageOptions)
    {
        Title = title;
    }
        
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }
}