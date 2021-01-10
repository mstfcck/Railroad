using Railroad.Receiver;

namespace Railroad.Abstractions
{
    public interface IRailroadCompanyReceiver
    {
        void AddRoute(Route route);
        void RunQuery(Query query);
    }
}