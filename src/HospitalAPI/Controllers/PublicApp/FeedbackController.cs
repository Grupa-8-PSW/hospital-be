using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _mapper = mapper;
            _feedbackService = feedbackService;
        }
        

        [HttpGet("public")]
        public ActionResult GetApprovedPublicFeedback()
        {
            return Ok(_mapper.Map<List<PublicFeedbackDTO>>(_feedbackService.GetAllApprovedPublic()));
        }

        [HttpGet]
        [Route ("{id}")]
        public ActionResult Get(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if(feedback is not null)
            {
                return Ok(_mapper.Map<PublicFeedbackDTO>(feedback));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateFeedback(CreateFeedbackDTO feedbackDTO)
        {
            var newFeedback = _feedbackService.Create(_mapper.Map<Feedback>(feedbackDTO));
            return CreatedAtAction(nameof(Get), new { id = newFeedback.Id }, _mapper.Map<PublicFeedbackDTO>(newFeedback));
        }

    }
}
