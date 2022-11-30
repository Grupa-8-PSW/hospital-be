using HospitalLibrary.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Patient : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public List<Feedback> Feedbacks { get; private set; }
        public List<Allergen> Allergens { get; set; }
        public Doctor selectedDoctor { get; set; }
        public int SelectedDoctorId { get; set; }
        public int UserId { get; set; }

        public Patient(int id, string firstName, string lastName, string email, string pin, Gender gender, BloodType bloodType, int addressId, int selectedDoctorId, int userId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Pin = pin;
            Gender = gender;
            BloodType = bloodType;
            AddressId = addressId;
            SelectedDoctorId = selectedDoctorId;
            UserId = userId;
        }

        public Patient(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Patient()
        {

        }
    }

}
