using Backend.Models;

namespace Backend.DTO
{
    public class EventDTO
    {


        public string EventName { get; set; } = null!;

        public string? Description { get; set; }

        public String StartDate { get; set; }
        public String startTime { get; set; }


        public String EndDate { get; set; }

        public String endTime { get; set; }


        public string? Location { get; set; }

        //public virtual ICollection<ApiEvent> ApiEvents { get; } = new List<ApiEvent>();

        //public virtual ICollection<Eventlog> Eventlogs { get; } = new List<Eventlog>();

        public virtual User User { get; set; } = null!;
    }
}
