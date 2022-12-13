namespace HospitalAPI.Responses;

public class ConsiliumResponse
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Duration { get; set; }
    public IEnumerable<ConsiliumDoctorResponse> Doctors { get; set; }
}