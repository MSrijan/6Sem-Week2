using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Week2.Constants;

namespace Week2.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string? ImageUrl {  get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;

        public bool isActive { get; set; }

    }
}
