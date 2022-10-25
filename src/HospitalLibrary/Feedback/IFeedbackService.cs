using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Feedback
{
    public interface IFeedbackService
    {
        public List<Feedback> GetAll();
        public Feedback GetById(int id);
        public Feedback Create(Feedback feedback);
        public void Update(Feedback feedback);
        public void Delete(int id);
        public List<Feedback> GetPublicFeedback();
    }
}
