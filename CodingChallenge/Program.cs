using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new List<string>
                {
                    "[25,30]",
                    "[2,19]",
                    "[14,23]",
                    "[4,8]"
                }.ToArray();
            }
            
            //deserialize args to list of Intervals
            var intervals = new List<Interval>();
            Helper.GenerateIntervals(args, intervals);

            //merge function
            var stack = Merge(intervals);

            //print results
            Console.WriteLine("Result intervals:");
            foreach (var element in stack)
            {
                Console.WriteLine(element.ToString());
            }
        }

        private static Stack<Interval> Merge(IList<Interval> intervals)
        {
            //order intervals by start, because End will be compared with next element's Start
            var sortedIntervals = intervals.ToArray();
            //sortedIntervals.Sort(new CustomComparer());
            Array.Sort(sortedIntervals, new CustomComparer());
            
            var stack = new Stack<Interval>();
            //push first element, in order to skip tryPeek
            stack.Push(sortedIntervals.First());
            for (int i = 1; i < sortedIntervals.Count(); i++)
            {
                var top = stack.Peek();
                if (top.End < sortedIntervals[i].Start)
                {
                    stack.Push(sortedIntervals[i]);
                }
                else if (top.End < sortedIntervals[i].End)
                {
                    top.End = sortedIntervals[i].End;
                }
            }

            return stack;
        }
    }
}