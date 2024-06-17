using ToastNotifications.Core;

namespace CustomNotificationsExample.MahAppsNotification;

public class MahAppsNotification : NotificationBase
{
    private MahAppsDisplayPart _displayPart;
    private string _title;

    public override NotificationDisplayPart DisplayPart => _displayPart ??= new MahAppsDisplayPart(this);

    public MahAppsNotification(string title, string message, MessageOptions messageOptions) : base(message, messageOptions)
    {
        Title = title;
        Message = message;
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