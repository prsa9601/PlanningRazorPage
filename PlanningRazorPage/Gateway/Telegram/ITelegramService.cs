using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Text;
using System.Security.Authentication;
using System.Net;

namespace PlanningRazorPage.Gateway.Telegram
{
    public interface ITelegramService
    {
        Task AddPost();
        Task DeletePost();
        Task EditPost();
    }
    public class TelegramService : ITelegramService
    {
        //private static readonly HttpClientHandler handler = new HttpClientHandler
        //{
        //    SslProtocols = SslProtocols.Tls12, 
        //    ServerCertificateCustomValidationCallback = 
        //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        //};
      
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _clientFactory;
        //private readonly HttpClientHandler handler;, HttpClientHandler _handler

        public TelegramService(HttpClient client, IHttpClientFactory clientFactory)
        {
            _client =client;
            _clientFactory = clientFactory;
        }
            //handler = _handler;

        public async Task AddPost()
        {
            //var handler = new HttpClientHandler
            //{
            //    UseCookies = true,
            //    CookieContainer = new CookieContainer(),
            //    Proxy = new WebProxy("http://proxyserver:8080"),
            //    UseProxy = true
            //};
            string BotToken = "8034643778:AAEEbUXrPRlpLtcPIPQulOxWMzCRVAQHbKw";
            string ChatId = "@ppud";  //نام کانال 
            string Message = "Default Message";
            string url = $"https://api.telegram.org/bot{BotToken}/sendMessage";
            var parameters = new JObject
            {
                { "chat_id", ChatId },
                { "text", Message }
            };
           var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(parameters),
                Encoding.UTF8, "application/json");
          
            _client.Timeout = TimeSpan.FromSeconds(100);
           // HttpResponseMessage response = await _client.PostAsync(url, content);

            //HttpResponseMessage response = await _client.PostAsync($"https://api.telegram.org/bot{BotToken}/sendMessage", content);
            var bot = new TelegramBotClient("8034643778:AAEEbUXrPRlpLtcPIPQulOxWMzCRVAQHbKw");

            // ارسال پیام متنی به کانال (با نام کاربری یا chat_id)
            var t = await bot.SendTextMessageAsync(ChatId, Message);

            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Message sent successfully!");
            //}
            //else
            //{
            //    Console.WriteLine($"Failed to send message: {response.StatusCode}");
            //}
        }
        //public async Task AddPost()
        //{
        //    string BotToken = "8034643778:AAEEbUXrPRlpLtcPIPQulOxWMzCRVAQHbKw";
        //    string ChatId = "@pp";  //نام کانال 
        //    string Message = "Default Message";
        //    string url = $"https://api.telegram.org:443/bot{BotToken}/sendMessage";
        //    // string proxyUrl = "http://localhost:5250/SocialMedia/Post/Add"; // آدرس پروکسی شما
        //    // handler.Proxy = new System.Net.WebProxy(proxyUrl, false);
        //    // handler.UseProxy = true;
        //    var parameters = new JObject
        //    {
        //        { "chat_id", ChatId },
        //        { "text", Message }
        //    };
            
        //    var content = new StringContent(parameters.ToString(),
        //        System.Text.Encoding.UTF8, "application/json");
        //    _client.Timeout = TimeSpan.FromSeconds(100);
        //    HttpResponseMessage response = await _client.PostAsync(url, content);
        //    //var bot = new TelegramBotClient("8034643778:AAEEbUXrPRlpLtcPIPQulOxWMzCRVAQHbKw");

        //    // ارسال پیام متنی به کانال (با نام کاربری یا chat_id)
        //    //var t = await bot.SendTextMessageAsync(ChatId, Message);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Message sent successfully!");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Failed to send message: {response.StatusCode}");
        //    }
        //}

        public async Task DeletePost()
        {
            Ping ping = new Ping(); 
            PingReply reply = ping.Send("api.telegram.org");
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Ping successful:"); 
                Console.WriteLine($"Address: {reply.Address}");
                Console.WriteLine($"RoundTrip time: {reply.RoundtripTime} ms");

            }
            else
            {
                Console.WriteLine($"Ping failed: {reply.Status}");
            }
            //var BotToken = "8034643778:AAEEbUXrPRlpLtcPIPQulOxWMzCRVAQHbKw";
            //var ChatId = "pp";  //نام کانال 
            //var Message = "Default Message";
            //string url = $"https://api.telegram.org/bot{BotToken}/sendMessage";
            //var parameters = new JObject
            //{
            //    { "chat_id", ChatId },
            //    { "text", Message }
            //};
            //var content = new StringContent(parameters.ToString(),
            //    System.Text.Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await _client.PostAsync(url, content);
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Message sent successfully!");
            //}
            //else
            //{
            //    Console.WriteLine($"Failed to send message: {response.StatusCode}");
            //}
        }
        
        public async Task EditPost()
        {
            var BotToken = "8034643778:AAEEbUXrPRlpLtcPIPQulOxWMzCRVAQHbKw";
            var ChatId = "pp";  //نام کانال 
            var Message = "Default Message";
            string url = $"https://api.telegram.org/bot{BotToken}/sendMessage";
            var parameters = new JObject
            {
                { "chat_id", ChatId },
                { "text", Message }
            };
            var content = new StringContent(parameters.ToString(),
                System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message sent successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to send message: {response.StatusCode}");
            }
        }
    }
}
