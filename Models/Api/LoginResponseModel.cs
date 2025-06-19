namespace WebAPI.Models.Api
{
    public class LoginResponseModel
    {
        public string? Username { get; set; }
        public string? AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public Guid UserId { get; set; }
    }
}
