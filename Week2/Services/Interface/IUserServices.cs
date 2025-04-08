using Week2.Dtos;
using Week2.Entities;

namespace Week2.Services.Interface
{
    public interface IUserServices
    {
        void AddUser(InsertUserDto userDto);

        List <User> GetAllUsers();

        User GetById(Guid id);

        void DeleteUser(Guid id);

        void UpdateUser(Guid id, InsertUserDto userDto);
    }
}
