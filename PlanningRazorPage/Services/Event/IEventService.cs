using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Event;

namespace PlanningRazorPage.Services.Event
{
    public interface IEventService
    { 
        Task<ApiResult?> Add(AddEventCommand command);
        Task<ApiResult?> Edit(EditEventCommand command);
        Task<ApiResult?> Delete(long id);
        //Task<ApiResult?> Delete(DeleteEventCommand command);
        Task<EventDto?> GetById(long Id);
        Task<EventDto?> GetByUserId(string userId);
    
    }
}
