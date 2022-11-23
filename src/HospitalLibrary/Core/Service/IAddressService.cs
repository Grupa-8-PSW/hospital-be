using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IAddressService
    {
        public List<Address> GetAll();
        public Address GetById(int id);
        public Address Create(Address address);
        public void Update(Address address);
        public void Delete(int id);
    }
}
