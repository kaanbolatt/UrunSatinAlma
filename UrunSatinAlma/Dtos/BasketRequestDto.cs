using UrunSatinAlma.Context;

namespace UrunSatinAlma.Dtos
{
    public class BasketRequestDto
    {
        public long Id { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
