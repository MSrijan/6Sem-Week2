using Week2.Dtos;

namespace Week2.Services.Interface
{
    public interface IUserServices
    {
        void AddUser(InsertUserDto userDto);

        List<GetAllUser> getallUsers();

        GetAllUser GetById(Guid id);

        void DeleteUser(Guid id);

        void UpdateUser(Guid id, InsertUserDto userDto);
    }
}
