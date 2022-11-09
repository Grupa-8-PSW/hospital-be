namespace HospitalLibrary.Core.Model
{
    public class Allergen : BaseEntityModel
    {
        public string Name { get; set; }

        public Allergen(string name)
        {
            Name = name;
        }
    }

}
