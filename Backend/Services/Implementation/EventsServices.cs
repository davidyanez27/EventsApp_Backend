using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;

namespace Backend.Services.Implementation
{
    public class EventsServices : IEventService
    {
        private BdeventsContext _dbContext;

        public EventsServices(BdeventsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await ExecuteDbOperation(() => _dbContext.Events.ToListAsync());
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await ExecuteDbOperation(async () =>
            {
                var eventItem = await _dbContext.Events.FindAsync(eventId);
                return eventItem ?? throw new InvalidOperationException("Event not found.");
            });
        }

        public async Task<Event> CreateEvent(Event eventItem)
        {
            return await ExecuteDbOperation(async () =>
            {
                _dbContext.Events.Add(eventItem);
                await _dbContext.SaveChangesAsync();
                return eventItem;
            });
        }

        public async Task<bool> UpdateEvent(Event eventItem)
        {
            return await ExecuteDbOperation(async () =>
            {
                _dbContext.Events.Update(eventItem);
                await _dbContext.SaveChangesAsync();
                return true;
            });
        }

        public async Task<bool> DeleteEvent(Event eventItem)
        {
            return await ExecuteDbOperation(async () =>
            {
                _dbContext.Events.Remove(eventItem);
                await _dbContext.SaveChangesAsync();
                return true;
            });
        }

        private async Task<T> ExecuteDbOperation<T>(Func<Task<T>> dbOperation)
        {
            try
            {
                return await dbOperation();
            }
            catch (Exception err)
            {
                // Log error or handle it as per your logging strategy
                throw;
            }
        }
    }
}
