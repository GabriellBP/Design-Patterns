﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPattern
{
    public class NotificationProvider : IObservable<NotificationEvent>
    {

        public string ProviderName { get; private set; }
        // Maintain a list of observers
        private List<IObserver<NotificationEvent>> _observers;

        public NotificationProvider(string _providerName)
        {
            ProviderName = _providerName;
            _observers = new List<IObserver<NotificationEvent>>();
        }

        // Define Unsubscriber class
        private class Unsubscriber : IDisposable
        {

            private List<IObserver<NotificationEvent>> _observers;
            private IObserver<NotificationEvent> _observer;

            public Unsubscriber(List<IObserver<NotificationEvent>> observers,
                                IObserver<NotificationEvent> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        // Define Subscribe method
        public IDisposable Subscribe(IObserver<NotificationEvent> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        // Notify observers when event occurs
        public void EventNotification(string description)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new NotificationEvent(ProviderName, description,
                                DateTime.Now));
            }
        }
    }
}
