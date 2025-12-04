namespace AwaitableNotifier.Console;

public class Notifier
{
    private static bool _isInitialized;
    private static event Action? NotificationEvent;
    private static readonly object _lock = new();

    public static void Subscribe(Action handler)
    {
        lock (_lock)
        {
            if (!_isInitialized)
            {
                NotificationEvent += handler;
                return;
            }
        }
        handler();
    }

    public static void Unsubscribe(Action handler)
    {
        lock (_lock)
        {
            NotificationEvent -= handler;
        }
    }

    public static void Notify()
    {
        Delegate[] handlers = Array.Empty<Delegate>();
        lock (_lock)
        {
            if (_isInitialized)
            {
                return;
            }
            _isInitialized = true;
            handlers = NotificationEvent?.GetInvocationList() ?? Array.Empty<Delegate>();
        }

        foreach (var handler in handlers)
        {
            handler.DynamicInvoke();
        }
    }
}
