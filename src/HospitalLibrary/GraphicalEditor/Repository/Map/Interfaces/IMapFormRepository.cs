using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces
{
    public interface IMapFormRepository
    {
        IEnumerable<MapForm> GetAll();
    }
}
