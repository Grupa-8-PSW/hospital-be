using HospitalLibrary.Shared;

namespace HospitalLibrary.Patient
{
    public class Patient : BaseEntityModel
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<Feedback.Feedback> Feedbacks { get; private set; }

        public Patient(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
