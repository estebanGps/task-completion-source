namespace AwaitableNotifier.Console;

internal class Subscriber(string name) : IDisposable
{
    private readonly string _name = name;

    public void Subscribe()
    {
        Notifier.Subscribe(OnNotified);

        System.Console.WriteLine($"{DateTime.UtcNow:T} Subscriber {_name}: subscribed to notification.");
    }

    public void Dispose()
    {
        Notifier.Unsubscribe(OnNotified);
        System.Console.WriteLine($"{DateTime.UtcNow:T} Subscriber {_name}: unsubscribed from notification.");
    }

    private void OnNotified()
    {
        System.Console.WriteLine($"{DateTime.UtcNow:T} Subscriber {_name}: received notification.");
    }
}
