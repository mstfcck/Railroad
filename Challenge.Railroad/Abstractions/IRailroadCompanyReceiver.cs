using Challenge.Railroad.Receiver;

namespace Challenge.Railroad.Abstractions
{
    public interface IRailroadCompanyReceiver
    {
        void AddRoute(Route route);
        void RunQuery(Query query);
    }
}