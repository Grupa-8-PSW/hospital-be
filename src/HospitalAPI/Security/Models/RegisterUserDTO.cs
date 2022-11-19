using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Security.Models
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public List<AllergenDTO> Allergens { get; set; }
        public Address Address { get; set; }
        public BloodType BloodType { get; set; }
        public Gender Gender { get; set; }


    }
}
