namespace PlanningRazorPage.Models.Auth
{

    public class LoginCommand
    {
        // public string Name { get; set; }
        public string UserName { get; set; }
        // public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool rememberMe { get; set; }
        //public string Email { get; set; }
    }
    public class RegisterCommand 
    {
        // public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        // public bool rememberMe { get; set; }
    }
    //public class LoginResponse
    //{
    //    public string Token { get; set; }
    //    public string RefreshToken { get; set; }
    //}
}
