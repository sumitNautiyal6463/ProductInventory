using System;

namespace ShopBridge.Models.Logins
{
    public class TokenResponse
    {
        public string Token { get; set; }       // jwt token
        public DateTime Expiration { get; set; }  // expiry time
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
