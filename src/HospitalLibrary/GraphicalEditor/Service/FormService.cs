using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public IEnumerable<Form> GetAll()
        {
            return _formRepository.GetAll();
        }

        public IEnumerable<Form> GetInformationsOfRooms(int id)
        {
            try
            {
                return _formRepository.GetInformationsOfRooms(id);

            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
