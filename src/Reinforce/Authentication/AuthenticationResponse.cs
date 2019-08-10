namespace Reinforce.Authentication
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string InstanceUrl { get; set; }
        public string Id { get; set; }
        public string IssuedAt { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string Signature { get; set; }
        public string State { get; set; }
        public string TokenType { get; set; }
    }
}