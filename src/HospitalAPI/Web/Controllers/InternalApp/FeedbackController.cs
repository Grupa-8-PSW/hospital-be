using HospitalLibrary.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Web.Controllers.InternalApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

    }
}
