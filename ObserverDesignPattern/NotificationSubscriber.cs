using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPattern
{
    public class NotificationSubscriber : IObserver<NotificationEvent>
    {
        public string SubscriberName { get; private set; }
        private IDisposable _unsubscriber;

        public NotificationSubscriber(string _subscriberName)
        {
            SubscriberName = _subscriberName;
        }

        public virtual void Subscribe(IObservable<NotificationEvent> provider)
        {
            // Subscribe to the Observable
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Done");
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        public virtual void OnNext(NotificationEvent ev)
        {
            Console.WriteLine($"Hey {SubscriberName} -> you received {ev.EventProviderName} {ev.Description} @ {ev.Date} ");
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
