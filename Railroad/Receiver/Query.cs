namespace Railroad.Receiver
{
    public class Query
    {
        public string From { get; }
        public string To { get; }

        public Query(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}