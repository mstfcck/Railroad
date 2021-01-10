using Railroad.Receiver;

namespace Railroad.Abstractions
{
    public interface IQueryCommand : ICommand
    {
        Query Query { get; set; }
        void SetReceiver(IRailroadCompanyReceiver railroadCompanyReceiver);
    }
}