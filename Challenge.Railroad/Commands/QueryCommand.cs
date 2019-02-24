using Challenge.Railroad.Abstractions;
using Challenge.Railroad.Receiver;

namespace Challenge.Railroad.Commands
{
    public class QueryCommand : IQueryCommand
    {
        private IRailroadCompanyReceiver _railroadCompanyReceiver;
        public Query Query { get; set; }

        public QueryCommand(Query query)
        {
            Query = query;
        }

        public void SetReceiver(IRailroadCompanyReceiver railroadCompanyReceiver)
        {
            _railroadCompanyReceiver = railroadCompanyReceiver;
        }

        public CommandType GetCommandType()
        {
            return CommandType.QueryCommand;
        }

        /// <summary>
        /// Runs the query in receiver
        /// </summary>
        public void Execute()
        {
            _railroadCompanyReceiver.RunQuery(Query);
        }
    }
}