using System.ComponentModel.DataAnnotations;

namespace Week2.Dtos
{
    public class InsertAddressDto
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; set; }
    }
}
