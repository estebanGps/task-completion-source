namespace AwaitableNotifier.Console;

public class SlowInitializationService
{
    public SlowInitializationService()
    {
        Intialize();
    }

    private static void Intialize()
    {
        System.Console.WriteLine($"{DateTime.UtcNow:T} SlowInitializationService: Starting slow initialization...");
        Thread.Sleep(10000);
        Notifier.Notify();
        System.Console.WriteLine($"{DateTime.UtcNow:T} SlowInitializationService: Finished slow initialization.");
    }
}
