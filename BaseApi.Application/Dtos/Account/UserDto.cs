namespace BaseApi.Application.Dtos.Account
{
    public class UserDto
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
