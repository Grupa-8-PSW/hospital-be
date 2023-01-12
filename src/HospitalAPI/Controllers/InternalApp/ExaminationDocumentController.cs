using System.Collections.ObjectModel;
using Castle.Core.Internal;
using HospitalAPI.Mapper;
using HospitalAPI.Responses;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


namespace HospitalAPI.Controllers.InternalApp
{
    [Route("api/internal/[controller]")]
    [ApiController]
    public class ExaminationDocumentController : ControllerBase
    {
        private readonly IExaminationDoneService _examinationDoneService;
        private readonly ISearchTextParserService _textParserService;
        private readonly IMapper<ExaminationDone, ExaminationDocumentResponse> _examinationDocumentMapper;


        public ExaminationDocumentController(IExaminationDoneService examinationDoneService,
            ISearchTextParserService textParserService,
            IMapper<ExaminationDone, ExaminationDocumentResponse> examinationDocumentMapper)
        {
            _examinationDoneService = examinationDoneService;
            _textParserService = textParserService;
            _examinationDocumentMapper = examinationDocumentMapper;
        }

        public ActionResult GetAll([FromQuery] string? searchText)
        {
            if (!searchText.IsNullOrEmpty())
            {
                var searchParts = _textParserService.ParseSearchText(searchText);
                var examDones = _examinationDoneService.GetAll()
                    .Where(exam =>
                    {
                        var include = false;
                        searchParts.ForEach(part =>
                        {
                            if (exam.Record.Contains(part, StringComparison.InvariantCultureIgnoreCase) ||
                                exam.Examination.Patient.FullName.Contains(part, StringComparison.InvariantCultureIgnoreCase) ||
                                exam.Examination.Doctor.FullName.Contains(part, StringComparison.InvariantCultureIgnoreCase) ||
                                exam.Examination.DateRange.Start.ToString().Contains(part, StringComparison.InvariantCultureIgnoreCase) ||
                                exam.Examination.DateRange.End.ToString().Contains(part, StringComparison.InvariantCultureIgnoreCase))
                            {
                                include = true;
                            }

                            exam.Prescriptions.ForEach(prescription =>
                            {
                                prescription.PrescriptionItem.ForEach(pi =>
                                {
                                    if (pi.MedicalDrug.Name.Contains(part, StringComparison.InvariantCultureIgnoreCase) ||
                                        pi.MedicalDrug.Code.Contains(part, StringComparison.InvariantCultureIgnoreCase) ||
                                        pi.MedicalDrug.Amount.ToString() == part)
                                    {
                                        include = true;
                                    }
                                });
                            });
                        });

                        return include;
                    }).ToList();
                var examDocuments = _examinationDocumentMapper.toDTO(
                    new Collection<ExaminationDone>(examDones));

                return Ok(examDocuments);
            }

            var examinationDocuments = _examinationDocumentMapper.toDTO(
                new Collection<ExaminationDone>(_examinationDoneService.GetAll().ToList()));

            return Ok(examinationDocuments);
        }


    }
}
