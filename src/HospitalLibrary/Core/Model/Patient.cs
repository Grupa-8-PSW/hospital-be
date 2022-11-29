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

        public Patient(int id, string firstName, string lastName, string email, string pin, Gender gender, BloodType bloodType, int addressId, int selectedDoctorId)
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
        }

        public Patient(int id, string firstName, string lastName, string v1, string v2, Gender mALE, BloodType zERO_POSITIVE) : this(id, firstName, lastName)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.mALE = mALE;
            this.zERO_POSITIVE = zERO_POSITIVE;
        }

        public Patient(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Patient()
        {

        }


    }

}
