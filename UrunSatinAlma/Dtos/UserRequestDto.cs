using UrunSatinAlma.Context;

namespace UrunSatinAlma.Dtos
{
    public class UserRequestDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }

    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
