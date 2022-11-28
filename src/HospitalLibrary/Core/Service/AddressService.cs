using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public Address Create(Address address)
        {
            return _addressRepository.Create(address);
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
        }

        public List<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public Address GetById(int id)
        {
            return _addressRepository.GetById(id);
        }

        public void Update(Address address)
        {
            _addressRepository.Update(address);
        }
    }
}
