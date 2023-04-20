namespace UrunSatinAlma.Context
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role{ get; set; }

    }
}
