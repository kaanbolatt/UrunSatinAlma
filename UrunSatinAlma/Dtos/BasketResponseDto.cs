namespace UrunSatinAlma.Dtos
{
    public class BasketResponseDto
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public long BasketId { get; set; }
    }
}
