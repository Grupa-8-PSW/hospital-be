namespace HospitalLibrary.Core.Model
{
    public class Allergen : BaseEntityModel
    {
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }

        public Allergen(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
