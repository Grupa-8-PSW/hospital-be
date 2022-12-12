using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Model.ValueObjects;

[Owned]
public class Pin : ValueObject
{
    public string Value { get; private set; }

    public Pin(string value)
    {
        Value = value;
        Validate();
    }

    public int CalculateAge()
    {
        string year = CalculateYear();
        DateTime birthDate = DateTime.Parse(year + "-" + Value.Substring(2, 2) + "-" + Value.Substring(0, 2));
        return new DateTime(DateTime.Now.Subtract(birthDate).Ticks).Year - 1;
    }

    private void Validate()
    {
        int day = Int32.Parse(Value.Substring(0, 2));
        int month = Int32.Parse(Value.Substring(2, 2));
        int year = Int32.Parse(CalculateYear());

        if (day < 0 || month < 0 || month > 12 || year < 0 || year > DateTime.Now.Year)
        {
            throw new ArgumentException("Invalid PIN.");
        }
        //else if (CheckIfDayExistsInMonth(day, month))
        //{
        //throw new ArgumentException("Invalid PIN. Month " + month + ". doesn't have that many days.");
        //}

    }

    private string CalculateYear()
    {
        string yearString;
        if (Int32.Parse(Value.Substring(4, 3)) > Int32.Parse(DateTime.Now.Year.ToString().Substring(1, 3)))
        {
            yearString = "1" + Value.Substring(4, 3);
        }
        else
        {
            yearString = "2" + Value.Substring(4, 3);
        }
        return yearString;
    }

    private bool CheckIfDayExistsInMonth(int day, int month)
    {
        bool retVal = true;
        if ((month == 1 && day > 31) || (month == 3 && day > 31) || (month == 5 && day > 31) || (month == 7 && day > 31) ||
            (month == 8 && day > 31) || (month == 10 && day > 31) || (month == 12 && day > 31) || (month == 4 && day > 30) ||
            (month == 6 && day > 30) || (month == 9 && day > 30) || (month == 11 && day > 30) || (month == 2 && day > 29))
        {
            retVal = false;
        }
        return retVal;
    }

    public override bool Equals(object? obj)
    {
        var valueObject = obj as Pin;

        return Value == valueObject.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}