using AutoMapper;
using HospitalAPI.Web.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Web.Controllers.PublicApp
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
        

        // GET: api/Feedback/public
        [HttpGet("public")]
        public ActionResult GetPublicFeedback()
        {
            return Ok(_mapper.Map<List<PublicFeedbackDTO>>(_feedbackService.GetAllPublic()));
        }

    }
}
