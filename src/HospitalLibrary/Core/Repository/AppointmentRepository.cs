using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Util;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<DateRange> GetDoctorsBusyAppointments(int doctorId, DateTime date)
            => _context.Examinations
            .Where(ex => ex.DoctorId == doctorId && ex.DateRange.Start.Date == date)
            .Select(dr => dr.DateRange)
            .ToList();

        public List<DateRange> GetDoctorsBusyAppointments(int doctorId, DateRange dateRange)
            => _context.Examinations
            .Where(ex => ex.DoctorId == doctorId && ex.DateRange.Start < dateRange.End && dateRange.Start < ex.DateRange.End)
            .Select(ex => ex.DateRange)
            .ToList();
    }
}
