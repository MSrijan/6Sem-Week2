using Week2.Data;
using Week2.Dtos;
using Week2.Entities;
using Week2.Services.Interface;

namespace Week2.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly ApplicationDbContext _context;

        public AddressServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAddress(InsertAddressDto addressDto)
        {
            var address = new Address
            {
                Id = Guid.NewGuid(),
                Address1 = addressDto.Address1,
                Address2 = addressDto.Address2,
                City = addressDto.City,
                State = addressDto.State,
                Zip = addressDto.Zip,
                UserId = addressDto.UserId
            };

            _context.Set<Address>().Add(address);
            _context.SaveChanges();
        }

        public void DeleteAddress(Guid id)
        {
            var address = _context.Set<Address>().Find(id);
            if (address == null)
            {
                throw new KeyNotFoundException("Address not found.");
            }

            _context.Set<Address>().Remove(address);
            _context.SaveChanges();
        }

        public List<Address> GetAllAddress()
        {
            return _context.Set<Address>().ToList();
        }

        public Address GetByUD(Guid id)
        {
            var address = _context.Set<Address>().Find(id);
            if (address == null)
            {
                throw new KeyNotFoundException("Address not found.");
            }

            return address;
        }

        public Address updateAddress(Guid id, InsertAddressDto addressDto)
        {
            var address = _context.Set<Address>().Find(id);
            if (address == null)
            {
                throw new KeyNotFoundException("Address not found.");
            }

            address.Address1 = addressDto.Address1;
            address.Address2 = addressDto.Address2;
            address.City = addressDto.City;
            address.State = addressDto.State;
            address.Zip = addressDto.Zip;
            address.UserId = addressDto.UserId;

            _context.Set<Address>().Update(address);
            _context.SaveChanges();

            return address;
        }
    }
}
