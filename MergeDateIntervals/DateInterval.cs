using System;

namespace MergeDateIntervals
{
    public class DateInterval
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateInterval(DateTime start, DateTime end)
        {
            Start = start.Date;
            End = end.Date;

            if (Start.Subtract(End).Ticks > 0)
            {
                throw new ArgumentException($"{nameof(Start)} must be before {nameof(End)}");
            }
        }

        public bool IsAdjacent(DateInterval other)
        {
            return End.AddDays(1) == other.Start || Start.AddDays(-1) == other.End;
        }

        public bool Overlap(DateInterval other)
        {
            return (End >= other.Start) ||
                   (Start >= other.End) ||
                   (Start <= other.Start && End >= other.End) ||
                   (other.Start <= Start && other.End >= End);
        }

        public override string ToString()
        {
            return $"[{Start.ToShortDateString()} - {End.ToShortDateString()}]";
        }
    }
}