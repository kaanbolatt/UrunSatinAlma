using UrunSatinAlma.Context;

namespace UrunSatinAlma.Dtos
{
    public class ProductRequestDto
    {
        public long Id{ get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public string Detail { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
