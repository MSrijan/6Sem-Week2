using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week2.Entities
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; } = string.Empty;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
