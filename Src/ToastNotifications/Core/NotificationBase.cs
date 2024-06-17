using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToastNotifications.Core;

public abstract class NotificationBase : INotification, INotifyPropertyChanged
{
    private string _message;
    private Action<INotification> _closeAction;

    protected NotificationBase(string message, MessageOptions options)
    {
        Message = message;

        Options = options ?? new MessageOptions();
    }

    public string Message 
    { 
        get => _message;
        protected set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public bool CanClose { get; set; } = true;

    public MessageOptions Options { get; }

    public abstract NotificationDisplayPart DisplayPart { get; }

    public int Id { get; set; }

    public virtual void Bind(Action<INotification> closeAction)
    {
        _closeAction = closeAction;
    }

    public virtual void Close()
    {
        Options?.CloseClickAction?.Invoke(this);
        _closeAction?.Invoke(this);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}