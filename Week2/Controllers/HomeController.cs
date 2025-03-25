using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Week2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        public static List<Item> items = new List<Item>
        {
            new Item { Id = Guid.NewGuid(), Name = "Item 1", Description = "Description 1" },
            new Item { Id = Guid.NewGuid(), Name = "Item 2", Description = "Description 2" },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Item newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            newItem.Id = Guid.NewGuid();
            items.Add(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Item updatedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            items.Remove(item);
            return NoContent();
        }
    }

    public class Item
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
