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

        public async Task<ApiResult<long>?> Add(AddEventCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.accessNotification.ToString()), "accessNotification");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.EndTime.ToString()), "EndTime");
            formData.Add(new StringContent(command.EventAddress.ToString()), "EventAddress");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            formData.Add(new StringContent(command.StartTime.ToString()), "StartTime");
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StringContent(command.userNames.ToString() ?? string.Empty), "userNames");
            formData.Add(new StringContent(command.notification.ToString()), "notification");
            formData.Add(new StringContent(command.tag.ToString()), "Tag");
           // formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            var result = await _client.PostAsJsonAsync($"{ModuleName}", command);
            return await result.Content.ReadFromJsonAsync<ApiResult<long>>();
            //formData.Add(new StringContent(command.accessNotification.ToString()), "accessNotification");
            //formData.Add(new StringContent(command.Description.ToString()), "Description");
            //formData.Add(new StringContent(command.EndTime.ToString()), "EndTime");
            //formData.Add(new StringContent(command.EventAddress.ToString()), "EventAddress");
            //formData.Add(new StringContent(command.Title.ToString()), "Title");
            //formData.Add(new StringContent(command.StartTime.ToString()), "StartTime");
            //formData.Add(new StringContent(command.Link), "Link");
            //formData.Add(new StringContent(command.userNames != null ? string.Join(",", command.userNames) : string.Empty), "userNames");
            //formData.Add(new StringContent(command.notification.ToString()), "notification");
            //formData.Add(new StringContent(command.Tag.ToString()), "Tag");
        }

        public async Task<ApiResult?> SetDates(SetDatesEventCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/SetDates", command);
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

        public async Task<ApiResult<long>?> Edit(EditEventCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.accessNotification.ToString()), "accessNotification");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.EndTime.ToString()), "EndTime");
            formData.Add(new StringContent(command.EventAddress.ToString()), "EventAddress");
            formData.Add(new StringContent(command.Title.ToString()), "title");
            formData.Add(new StringContent(command.StartTime.ToString()), "StartTime");
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StringContent(command.userNames.ToString()), "userNames");
            formData.Add(new StringContent(command.notification.ToString()), "notification");
            formData.Add(new StringContent(command.tag.ToString()), "Tag");
            // formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            var result = await _client.PatchAsJsonAsync($"{ModuleName}", command);
            return await result.Content.ReadFromJsonAsync<ApiResult<long>>();
        }

        public async Task<EventDto?> GetById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<EventDto?>>($"{ModuleName}{id}");
            return result?.Data;
        }

        public async Task<List<EventDto?>> GetByUserId()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<EventDto?>>>($"{ModuleName}/GetByUserId");
            return result?.Data;
        }
    }
}
