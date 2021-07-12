namespace ShopBridge.Models.Logins
{
    public class TokenRequest
    {
        public string ClientId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
