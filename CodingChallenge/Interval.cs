namespace CodingChallenge
{
    public class Interval
    {
        public int End { get; set; }
        public int Start { get; init; }
        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"[{Start}, {End}]";
        }
    }
}