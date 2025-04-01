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
    }
}
