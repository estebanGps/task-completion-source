namespace AwaitableNotifier.Console;

public class Notifier
{
    private static bool _isInitialized;
    private static event Action? NotificationEvent;
    private static readonly object _lock = new();

    public static void Subscribe(Action handler)
    {
        if (_isInitialized)
        {
            handler();
            return;
        }
        lock (_lock)
        {
            NotificationEvent += handler;
        }
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
        lock (_lock)
        {
            if (_isInitialized)
            {
                return;
            }
            _isInitialized = true;
        }

        Delegate[] handlers = NotificationEvent?.GetInvocationList() ?? Array.Empty<Delegate>();
        foreach (var handler in handlers)
        {
            handler.DynamicInvoke();
        }
    }
}
