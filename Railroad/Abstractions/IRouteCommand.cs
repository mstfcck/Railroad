using Railroad.Receiver;

namespace Railroad.Abstractions
{
    public interface IRouteCommand : ICommand
    {
        Route Route { get; set; }
        void SetReceiver(IRailroadCompanyReceiver railroadCompanyReceiver);
    }
}
