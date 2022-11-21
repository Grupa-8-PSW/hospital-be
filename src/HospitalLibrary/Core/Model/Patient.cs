using HospitalLibrary.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Patient : BaseEntityModel
    {
        private string v1;
        private string v2;
        private Gender mALE;
        private BloodType zERO_POSITIVE;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }

        public List<Feedback> Feedbacks { get; private set; }

        public Patient(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Patient(int id, string firstName, string lastName, string v1, string v2, Gender mALE, BloodType zERO_POSITIVE) : this(id, firstName, lastName)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.mALE = mALE;
            this.zERO_POSITIVE = zERO_POSITIVE;
        }

        public Patient()
        {
        }
    }

}
