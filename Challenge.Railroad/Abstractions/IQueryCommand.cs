using Challenge.Railroad.Receiver;

namespace Challenge.Railroad.Abstractions
{
    public interface IQueryCommand : ICommand
    {
        Query Query { get; set; }
        void SetReceiver(IRailroadCompanyReceiver railroadCompanyReceiver);
    }
}