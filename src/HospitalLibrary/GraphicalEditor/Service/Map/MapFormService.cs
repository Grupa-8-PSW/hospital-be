using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model.Map;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Map.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service.Map
{
    public class MapFormService : IMapFormService
    {
        private readonly IMapFormRepository _formRepository;

        public MapFormService(IMapFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public IEnumerable<MapForm> GetAll()
        {
            return _formRepository.GetAll();
        }
    }
}
