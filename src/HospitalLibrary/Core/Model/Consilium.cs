using HospitalLibrary.Core.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Model;

public class Consilium : BaseEntityModel
{
    private List<Doctor> _doctors = new List<Doctor>();
    public string Subject { get; private set; }

    public DateRange Interval { get; private set; }
    public int Duration { get; private set; }

    public virtual List<Doctor> Doctors
    {
        get => new List<Doctor>(_doctors);
        private set => _doctors = value;
    }

    public Consilium(int id, string subject, DateRange interval, int duration)
    {
        Id = id;
        Subject = subject;
        Duration = duration;
        Interval = interval;
        _doctors = new List<Doctor>();
        Validate();
    }

    public Consilium(int id, string subject, DateRange interval, int duration,
        List<Doctor> doctors)
    {
        Id = id;
        Subject = subject;
        Duration = duration;
        Interval = interval;
        _doctors = doctors;
        Validate();
    }

    public Consilium(string subject, DateRange interval, int duration)
    {
        Subject = subject;
        Duration = duration;
        Interval = interval;
        _doctors = new List<Doctor>();
        Validate();
    }

    public Consilium()
    {

    }

    private void Validate()
    {
        if (Duration < 0)
            throw new ArgumentException("Duration must be positive number");
    }
}