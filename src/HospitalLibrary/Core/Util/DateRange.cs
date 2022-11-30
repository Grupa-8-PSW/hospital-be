
namespace HospitalLibrary.Core.Util
{
    public class DateRange
    {
        public DateTime From { get; }
        public DateTime To { get; }

        public DateRange(DateTime from, DateTime to)
        {
            if (from >= to)
                throw new Exception("Invalid range");
            From = from;
            To = to;
        }

        public bool Contains(DateTime date) =>  (date >= From && date <= To);

        public bool IsOverlapped(DateRange dateRange) => (From < dateRange.To && dateRange.From < To);

        public DateRange ExtendByDays(int days)
        {
            var from = From.AddDays(-days);
            var to = To.AddDays(days);
            if (from >= to)
                throw new Exception("Date range too small for extension");
            return new DateRange(from, to);
        }

        public override bool Equals(object? obj)
        {
            var valueObject = obj as DateRange;

            return From == valueObject.From
                && To == valueObject.To;
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode();
        }

    }
}
