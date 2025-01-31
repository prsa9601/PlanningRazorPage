using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Event;

namespace PlanningRazorPage.Services.Event
{
    public class EventService : IEventService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;
        private const string ModuleName = "Event";

        public EventService(HttpClient client, IHttpContextAccessor accessor)
        {
            _client = client;
            _accessor = accessor;
        }

        public async Task<ApiResult?> Add(AddEventCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.accessNotification.ToString()), "accessNotification");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.EndTime.ToString()), "EndTime");
            formData.Add(new StringContent(command.EventAddress.ToString()), "EventAddress");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            formData.Add(new StringContent(command.StartTime.ToString()), "StartTime");
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StringContent(command.userNumber.ToString() ?? string.Empty), "userNumber");
            formData.Add(new StringContent(command.notification.ToString()), "notification");
            formData.Add(new StringContent(command.tag.ToString()), "tag");
           // formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            var result = await _client.PostAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Delete(long id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        //public async Task<ApiResult?> Delete(DeleteEventCommand command)
        //{
        //    var result = await _client.DeleteAsync($"{ModuleName}/{id}");
        //    return await result.Content.ReadFromJsonAsync<ApiResult>();
        //}

        public async Task<ApiResult?> Edit(EditEventCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.accessNotification.ToString()), "accessNotification");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.EndTime.ToString()), "EndTime");
            formData.Add(new StringContent(command.EventAddress.ToString()), "EventAddress");
            formData.Add(new StringContent(command.Title.ToString()), "title");
            formData.Add(new StringContent(command.StartTime.ToString()), "StartTime");
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StringContent(command.userNumber.ToString()), "userNumber");
            formData.Add(new StringContent(command.notification.ToString()), "notification");
            formData.Add(new StringContent(command.tag.ToString()), "tag");
            // formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            var result = await _client.PatchAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<EventDto?> GetById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<EventDto?>>($"{ModuleName}{id}");
            return result?.Data;
        }

        public async Task<EventDto?> GetByUserId(string userId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<EventDto?>>($"{ModuleName}/GetByUserId{userId}");
            return result?.Data;
        }
    }
}
