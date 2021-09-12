using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPattern
{
    public class NotificationEvent
    {
        public string EventProviderName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public NotificationEvent(string _eventProviderName, string _description, DateTime _date)
        {
            EventProviderName = _eventProviderName;
            Description = _description;
            Date = _date;
        }
    }
}
