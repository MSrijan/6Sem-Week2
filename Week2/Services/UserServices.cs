using Week2.Data;
using Week2.Dtos;
using Week2.Entities;
using Week2.Services.Interface;

namespace Week2.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(InsertUserDto userDto)
        {
            try
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageUrl = userDto.ImageUrl,
                    RegisteredDate = userDto.RegisteredDate,
                    isActive = true
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetById(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User UpdateUser(Guid id, User user)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(x => x.Id == id);
                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Gender = user.Gender;
                existingUser.ImageUrl = user.ImageUrl;
                existingUser.RegisteredDate = user.RegisteredDate;
                existingUser.isActive = user.isActive;

                _context.Users.Update(existingUser);
                _context.SaveChanges();

                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
