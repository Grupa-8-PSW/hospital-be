namespace HospitalAPI.Security.Models
{
    public class RegisterRequest
    {
        public RegisterUserDTO RegisterUser { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
