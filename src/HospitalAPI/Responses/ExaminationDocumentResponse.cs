using HospitalAPI.DTO;

namespace HospitalAPI.Responses;

public class ExaminationDocumentResponse
{
    public string Report { get; set; }
    public string Doctor { get; set; }
    public string Patient { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public List<ExaminationDocumentPrescriptionDTO> Prescriptions { get; set; }
}