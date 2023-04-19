namespace UrunSatinAlma.Context
{
    public class Basket
    {
        public long Id { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
