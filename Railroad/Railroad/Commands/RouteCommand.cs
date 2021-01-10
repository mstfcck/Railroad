using Railroad.Abstractions;
using Railroad.Receiver;

namespace Railroad.Commands
{
    public class RouteCommand : IRouteCommand
    {
        private IRailroadCompanyReceiver _railroadCompanyReceiver;
        public Route Route { get; set; }

        public RouteCommand(Route route)
        {
            Route = route;
        }

        public void SetReceiver(IRailroadCompanyReceiver railroadCompanyReceiver)
        {
            _railroadCompanyReceiver = railroadCompanyReceiver;
        }

        public CommandType GetCommandType()
        {
            return CommandType.RouteCommand;
        }

        /// <summary>
        /// Adds a route to the receiver
        /// </summary>
        public void Execute()
        {
            _railroadCompanyReceiver.AddRoute(Route);
        }
    }
}