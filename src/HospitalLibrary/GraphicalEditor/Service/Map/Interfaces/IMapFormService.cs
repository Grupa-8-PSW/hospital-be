using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model.Map;

namespace HospitalLibrary.GraphicalEditor.Service.Map.Interfaces
{
    public interface IMapFormService
    {
        IEnumerable<MapForm> GetAll();
    }
}
