using System.Collections.Generic;

namespace CodingChallenge
{
    internal class CustomComparer : IComparer<Interval>
    {
        //custom comparer
        public int Compare(Interval x, Interval y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var startComparison = x.Start.CompareTo(y.Start);
            if (startComparison == -1)
            {
                return -1;
            }
            return 1;
        }
    }
}