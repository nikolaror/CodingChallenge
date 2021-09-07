using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    internal static class Helper
    {
        public static void GenerateIntervals(IEnumerable<string> args, ICollection<Interval> intervals)
        {
            foreach (var arg in args)
            {
                var interval = Helper.Deserialize(arg);
                intervals.Add(interval);
            }
        }

        private static Interval Deserialize(string arg)
        {
            arg = arg.Replace("[", String.Empty).Replace("]", String.Empty);
            var split = arg.Split(',');
            if (split.Length != 2)
            {
                throw new Exception("Please provide valid interval");
            }

            var parsed = Int32.TryParse(split[0], out var start);
            parsed = Int32.TryParse(split[1], out var end);
            if(!parsed)
            {
                throw new Exception("Please provide valid numbers in interval");
            }

            if (end <= start)
            {
                throw new Exception("Please provide valid start and end");
            }
            
            return new Interval(start, end);
        }
    }
}