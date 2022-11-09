using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class BaseEntityModel
    {
        [Key]
        public int Id { get; protected set; }
    }
}
