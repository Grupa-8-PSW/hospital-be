using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IBuildingService
    {
        IEnumerable<Building> GetAll();
    }
}
