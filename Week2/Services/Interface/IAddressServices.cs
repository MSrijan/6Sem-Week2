using Week2.Dtos;
using Week2.Entities;

namespace Week2.Services.Interface
{
    public interface IAddressServices
    {
        void AddAddress(InsertAddressDto addressDto);

        List<Address> GetAllAddress();

        Address GetByUD(Guid id);

        void DeleteAddress(Guid id);

        Address updateAddress(Guid id, InsertAddressDto addressDto);
    }
}
