using System;
using System.Collections.Generic;

namespace Level5_DDD
{
    // 263. Domain Events Dispatcher.
    // When something significant happens in the domain (e.g., "SafetyIncidentReported"), 
    // an event is triggered. Other parts of the system react without being tightly coupled.

    public class DomainEventDispatcher
    {
        private static readonly List<Action<object>> _handlers = new();

        public static void Subscribe<T>(Action<T> handler) => 
            _handlers.Add(obj => { if (obj is T e) handler(e); });

        public static void Raise<T>(T domainEvent)
        {
            Console.WriteLine($"[Event Raised] {typeof(T).Name}");
            _handlers.ForEach(h => h(domainEvent));
        }
    }

    public record SafetyIncidentReported(string SiteId, string Severity);

    class Program
    {
        static void Main()
        {
            DomainEventDispatcher.Subscribe<SafetyIncidentReported>(e => 
                Console.WriteLine($" -> [Notification Service] Alerting Emergency Response for Site {e.SiteId}!"));

            DomainEventDispatcher.Raise(new SafetyIncidentReported("S-104", "Critical"));
        }
    }
}