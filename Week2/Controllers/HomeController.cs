using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Week2.Constants;
using Week2.Data;
using Week2.Dtos;
using Week2.Entities;

namespace Week2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] InsertUserDto userDto)
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
                return Ok("user added successfully");

            }
            catch (Exception err)
            {
                return BadRequest(new { message = err.Message });
            }
        }
    }
}
