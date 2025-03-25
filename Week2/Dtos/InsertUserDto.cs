using Week2.Constants;

namespace Week2.Dtos
{
    public class InsertUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }

        public string? ImageUrl { get; set; }   
        public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;
    }
}
