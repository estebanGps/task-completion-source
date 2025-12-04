# C# Event Notifier to Multiple Subscribers
This repo demonstrates a notifier implementation based on events, using as example a dummy service class that has a slow initialization, and other clases that wish to be notified when the initialization is complete so they can start using it.

## How it works
### Notifier
The Notifier class holds a list of all the event handlers it will need to invoke once it is time for it to Notify. If notification has already happened, then it will invoke all new handlers immediately upon registration. Subscribing and unsubscribing is implemented in a thread-safe manner.

### Subscriber
A subscriber that wishes to be notified must simply call the Notifier.Subscribe() method passing a callback that returns nothing and takes no parameters. The Subscriber should also implement IDisposable and unsubscribe when disposed, or unsubscribe at a later convenient time (but not unsubscribe on the callback method itself, because this would alter the list of invocation targets and generate an exception).

### Notifying
A slow running process that wishes to notify once it is complete, must simply call the static method Notifier.Notify() once.

## Example
This is console output you get when running the application. You can see how if a subscriber subscibes after the Notifier.Notify() method has already been called, then the callback will be invoked immediately.
<img width="1447" height="307" alt="console output" src="https://github.com/user-attachments/assets/af93ff49-3f03-4116-bb49-2822c0fa77da" />
