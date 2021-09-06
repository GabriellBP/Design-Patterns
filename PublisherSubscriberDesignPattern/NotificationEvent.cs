﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PublisherSubscriberDesignPattern
{
    class NotificationEvent
    {
        public string NotificationMessage { get; private set; }

        public DateTime NotificationDate { get; private set; }

        public NotificationEvent(DateTime _dateTime, string _message)
        {
            NotificationDate = _dateTime;
            NotificationMessage = _message;
        }

    }
}
