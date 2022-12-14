using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Model.ValueObjects;

[Owned]
public class DateRange : ValueObject
{
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }

    public DateRange(DateTime from, DateTime to)
    {
        From = from;
        To = to;
        Validate();
    }

    public bool Includes(DateTime date)
    {
        return date >= From && date <= To;
    }

    public bool IncludesRange(DateRange dateRange)
    {
        return (dateRange.From >= From && dateRange.From <= To) &&
               (dateRange.To >= From && dateRange.To <= To);
    }

    public bool OverlapsWith(DateRange dateRange)
    {
        return (dateRange.From >= From && dateRange.From <= To) ||
               (dateRange.To >= From && dateRange.To <= To);
    }
    private void Validate()
    {
        if (From > To)
            throw new ArgumentException("Invalid arguments, from must be before to");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}