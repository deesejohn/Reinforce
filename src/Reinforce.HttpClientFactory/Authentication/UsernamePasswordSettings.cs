namespace Reinforce.HttpClientFactory.Authentication
{
    public class UsernamePasswordSettings
    {
        public string GrantType => "password";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}