using Backend.Models;

namespace Backend.DTO
{
    public class UserDTO
    {
        //public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; } = new List<Event>();
    }
}
