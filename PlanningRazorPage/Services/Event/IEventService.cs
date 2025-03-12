using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Event;

namespace PlanningRazorPage.Services.Event
{
    public interface IEventService
    { 
        Task<ApiResult<long>?> Add(AddEventCommand command);
        Task<ApiResult<long>?> Edit(EditEventCommand command);
        Task<ApiResult?> SetDates(SetDatesEventCommand command);
        Task<ApiResult?> Delete(long id);
        //Task<ApiResult?> Delete(DeleteEventCommand command);
        Task<EventDto?> GetById(long Id);
        Task<List<EventDto?>> GetByUserId();
    
    }
}
