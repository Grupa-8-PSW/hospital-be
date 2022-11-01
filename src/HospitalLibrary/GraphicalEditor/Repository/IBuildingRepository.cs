using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetAll();
    }
}
