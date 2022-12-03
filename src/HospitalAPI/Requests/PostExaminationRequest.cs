namespace HospitalAPI.Requests;

public class PostExaminationRequest
{
    public int PatientId { get; set; }
    public string StartTime { get; set; }
    public int Duration { get; set; }
}