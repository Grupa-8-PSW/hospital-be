using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HospitalLibrary.Core.Model.ValueObjects;

[Owned]
public class DateRange : ValueObject
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    [JsonIgnore]
    public int DurationInMinutes { get => (int)(End - Start).TotalMinutes; }

    public DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
        Validate();
    }

    public bool Includes(DateTime date)
    {
        return date >= Start && date <= End;
    }

    public bool IncludesRange(DateRange dateRange)
    {
        return (dateRange.Start >= Start && dateRange.Start <= End) &&
               (dateRange.End >= Start && dateRange.End <= End);
    }

    public bool OverlapsWith(DateRange dateRange)
    {
        return (dateRange.Start >= Start && dateRange.Start <= End) ||
               (dateRange.End >= Start && dateRange.End <= End);
    }
    private void Validate()
    {
        if (Start > End)
            throw new ArgumentException("Invalid arguments, from must be before to");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }

    public bool Contains(DateTime date) => (date >= Start && date < End);

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
}