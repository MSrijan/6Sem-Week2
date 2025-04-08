using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Week2.Constants;
using Week2.Data;
using Week2.Dtos;
using Week2.Entities;
using Week2.Services.Interface;

namespace Week2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController(IUserServices userServices) : ControllerBase
    {


        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] InsertUserDto userDto)
        {
            try
            {
                userServices.AddUser(userDto);
                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("getAll")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = userServices.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetUser(Guid id) // Changed parameter type from int to Guid
        {
            try
            {
                var user = userServices.GetById(id); // No changes needed here as id is now of type Guid
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                userServices.DeleteUser(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] InsertUserDto userDto)
        {
            try
            {
                var updatedUser = userServices.UpdateUser(id, userDto);
                if (updatedUser == null)
                {
                    return NotFound("User not found");
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
