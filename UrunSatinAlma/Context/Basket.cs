namespace UrunSatinAlma.Context
{
    public class Basket
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long ProductId { get; set; }
        public virtual Products? Products { get; set; }

    }
}
