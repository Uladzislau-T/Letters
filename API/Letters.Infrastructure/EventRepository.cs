using Letters.Domain.Dto;
using Letters.Domain.Models;
using Letters.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure
{
    public class EventRepository : RepositoryBase<Mail>, IMailRepository
    {
        public EventRepository(Context repositoryContext)
            : base(repositoryContext)
        {            
        }        

        public async Task<IEnumerable<Mail>> GetAllEventsAsync(CreateMailDto eventParameters, bool trackChanges)
        {
            var eventsQuery = FindAll(trackChanges)
                .Include(e => e.Recipients)
                .Select(e => e);
                      
            var planningEvents = await ChangeEventArrayAsync(eventsQuery, eventParameters);
            return planningEvents;
        }

        public async Task<IEnumerable<Mail>> GetAllEventsByCreatorAsync(string userName, bool trackChanges)
        {
            
            var eventsQuery = FindByCondition(e => e.UserCreator.UserName == userName, trackChanges);

            var eventParameters = new EventParameters();

            var planningEvents = await ChangeEventArrayAsync(eventsQuery, eventParameters);                       

            return planningEvents;
        }

        public async Task CreateEventAsync(Mail planningEvent)
        {
           await Create(planningEvent);
        }

        public async Task<Mail> GetEventbyIdAsync(int id, bool trackChanges = false)
        {
           return await FindByCondition(e => e.Id == id, trackChanges).Include(e => e.Members).FirstOrDefaultAsync();           
        }

        public async Task<Mail> GetEventbyTitleAsync(string title, bool trackChanges = false)
        {
           return await FindByCondition(e => e.Title == title, trackChanges).Include(e => e.Members).FirstOrDefaultAsync();           
        }

        public async Task<int> GetEventCountAsync(bool trackChanges = false)
        {
           return await FindAll(trackChanges).CountAsync();           
        }

        // public void DeleteEvent(Event Event)
        // {
        //     Delete(Event);
        // }

    }
}
