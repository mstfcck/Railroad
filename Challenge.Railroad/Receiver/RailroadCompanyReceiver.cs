using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Railroad.Abstractions;

namespace Challenge.Railroad.Receiver
{
    public class RailroadCompanyReceiver : IRailroadCompanyReceiver
    {
        private readonly List<Route> _routes;

        public RailroadCompanyReceiver()
        {
            _routes = new List<Route>();
        }

        public void AddRoute(Route route)
        {
            _routes.Add(route);
        }

        public void RunQuery(Query query)
        {
            var route = _routes.FirstOrDefault(f => f.From == query.From && f.To == query.To);
            if (route != null)
            {
                Console.WriteLine($"{route.From}-{route.To}:{route.Distance}");
            }
            else
            {
                Console.WriteLine($"{query.From}-{query.To}:-");
            }
            _routes.Clear();
        }
    }
}