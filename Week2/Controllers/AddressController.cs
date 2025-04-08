using Microsoft.AspNetCore.Mvc;
using Week2.Dtos;
using Week2.Services.Interface;

namespace Week2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AddressController(IAddressServices addressServices, IUserServices userServices) : ControllerBase
    {
        [HttpPost("Add")]
        public IActionResult AddAddress([FromBody] InsertAddressDto address)
        {
            try
            {
                // Validate if the UserId exists
                var user = userServices.GetById(address.UserId);
                if (user == null)
                {
                    return BadRequest($"User with ID: {address.UserId} does not exist.");
                }

                addressServices.AddAddress(address);
                return Ok("Address added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAllAddress()
        {
            try
            {
                var addresses = addressServices.GetAllAddress();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAddress(Guid id)
        {
            try
            {
                var address = addressServices.GetByUD(id);
                if (address == null)
                {
                    return NotFound($"No address found for ID: {id}");
                }
                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAddress(Guid id)
        {
            try
            {
                addressServices.DeleteAddress(id);
                return Ok($"Address with ID: {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateAddress(Guid id, [FromBody] InsertAddressDto addressDto)
        {
            try
            {
                // Validate if the UserId exists
                var user = userServices.GetById(addressDto.UserId);
                if (user == null)
                {
                    return BadRequest($"User with ID: {addressDto.UserId} does not exist.");
                }

                var updated = addressServices.updateAddress(id, addressDto);
                if (updated == null)
                {
                    return NotFound($"No address found for ID: {id}");
                }
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
