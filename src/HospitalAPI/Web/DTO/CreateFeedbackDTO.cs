using HospitalLibrary.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Web.DTO
{
    public class CreateFeedbackDTO
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public bool IsAnonymous { get; set; }
    }
}
