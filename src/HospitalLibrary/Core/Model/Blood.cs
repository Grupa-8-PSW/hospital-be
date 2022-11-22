using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Blood : BaseEntityModel
    {
        #region Properties

        public BloodType Type { get; set; }
        public int Quantity { get; set; }

        #endregion

        #region Constructor

        public Blood(BloodType type, int q, int id)
        {
            Id = id;
            Type = type;
            Quantity = q;
        }

        public Blood(): base()
        {

        }

        #endregion
    }
}
