using Backend.Models;

namespace Backend.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<Event> CreateEvent(Event eventItem);
        Task<bool> UpdateEvent(Event eventItem);
        Task<bool> DeleteEvent(Event eventItem);
    }
}
