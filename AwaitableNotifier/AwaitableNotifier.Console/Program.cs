using AwaitableNotifier.Console;

using Subscriber subscriber1 = new("One");
using Subscriber subscriber2 = new("Two");
using Subscriber subscriber3 = new("Three");

subscriber1.Subscribe();
subscriber2.Subscribe();

// SlowInitializationService takes 10 seconds to initialize
Task.Run(() => { SlowInitializationService service = new(); });

var timer = new Timer(_ =>
{
    // subscriber3 subscribes after 20 seconds (when initialization is complete) so its callback is invoked immediately
    subscriber3.Subscribe();
}, null, 20000, 0);

Console.ReadLine();