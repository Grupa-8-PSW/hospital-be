
using System.Text.Json.Serialization;

namespace HospitalLibrary.Core.Util
{
    public class DateRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        [JsonIgnore]
        public int DurationInMinutes { get => (int)(End - Start).TotalMinutes; }

        public DateRange(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new Exception("Invalid range");
            Start = start;
            End = end;

        }

        public bool Contains(DateTime date) =>  (date >= Start && date < End);

        public bool IsOverlapped(DateRange dateRange) => (Start < dateRange.End && dateRange.Start < End);

        public DateRange ExtendByDays(int days)
        {
            var from = Start.AddDays(-days);
            var to = End.AddDays(days);
            if (from >= to)
                throw new Exception("Date range too small for extension");
            return new DateRange(from, to);
        }

        public DateRange ExtendEndByMinutes(int minutes)
        {
            return new DateRange(
                Start,
                End.AddMinutes(minutes));
        }

        public IEnumerable<DateTime> EachDay()
        {
            for (var day = Start.Date; day.Date <= End.Date; day = day.AddDays(1))
                yield return day;
        }

        public override bool Equals(object? obj)
        {
            var valueObject = obj as DateRange;

            return Start == valueObject.Start
                && End == valueObject.End;
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ End.GetHashCode();
        }

    }
}
