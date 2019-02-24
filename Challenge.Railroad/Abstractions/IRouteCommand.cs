using Challenge.Railroad.Receiver;

namespace Challenge.Railroad.Abstractions
{
    public interface IRouteCommand : ICommand
    {
        Route Route { get; set; }
        void SetReceiver(IRailroadCompanyReceiver railroadCompanyReceiver);
    }
}
