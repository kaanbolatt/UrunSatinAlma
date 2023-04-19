using UrunSatinAlma.Context;

namespace UrunSatinAlma.Dtos
{
    public class ProductFilterDto
    {
        public string? GeneralSearch { get; set; }
        public long? CategoryId{ get; set; }
    }
}
