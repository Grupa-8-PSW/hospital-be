using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enums;

namespace HospitalAPI.DTO
{
    public class ConsiliumRequestDTO
    {
        public string Subject { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Duration { get; set; }
        public bool IsDoctors { get; set; }
        public List<int>? DoctorIds { get; set; }
        public List<string>? DoctorSpecializationsWanted { get; set; }

        public ConsiliumRequestDTO()
        {
        }

        public ConsiliumRequestDTO(string subject, string fromDate, string toDate, int duration, bool isDoctors, List<int>? doctorIds, List<string>? doctorSpecializationsWanted)
        {
            Subject = subject;
            FromDate = fromDate;
            ToDate = toDate;
            Duration = duration;
            IsDoctors = isDoctors;
            DoctorIds = doctorIds;
            DoctorSpecializationsWanted = doctorSpecializationsWanted;
        }

    }
}
