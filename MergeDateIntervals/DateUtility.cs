using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeDateIntervals
{
    public class DateUtility
    {
        public IEnumerable<DateInterval> MergeDateIntervals(IList<DateInterval> dateIntervals)
        {
            if (dateIntervals == null) throw new ArgumentNullException(nameof(dateIntervals));
            if (dateIntervals.Count < 2) return dateIntervals;

            var sortedDateIntervals = dateIntervals.OrderBy(x => x.Start).ToList();
            var mergedDateIntervals = new Stack<DateInterval>();
            mergedDateIntervals.Push(sortedDateIntervals[0]);

            foreach (var dateInterval in sortedDateIntervals.Skip(1))
            {
                var lastMergedInterval = mergedDateIntervals.Peek();
                if (!TryMergeIntervals(lastMergedInterval, dateInterval, out var mergedDateInterval))
                {
                    mergedDateIntervals.Push(dateInterval);
                    continue;
                }

                mergedDateIntervals.Pop();
                mergedDateIntervals.Push(mergedDateInterval);
            }

            return mergedDateIntervals.Reverse().ToList();
        }

        private static bool TryMergeIntervals(DateInterval interval1, DateInterval interval2, out DateInterval result)
        {
            if (!interval1.IsAdjacent(interval2) && !interval1.Overlap(interval2))
            {
                result = null;
                return false;
            }

            var startDate = interval1.Start < interval2.Start ? interval1.Start : interval2.End;
            var endDate = interval1.End > interval2.End ? interval1.End : interval2.End;

            result = new DateInterval(startDate, endDate);
            return true;
        }
    }
}
