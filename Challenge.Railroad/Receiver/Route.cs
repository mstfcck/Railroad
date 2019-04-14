namespace Challenge.Railroad.Receiver
{
    public class Route
    {
        public string From { get; }
        public string To { get;  }
        public int Distance { get; }

        public Route(string from, string to, int distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }
    }
}