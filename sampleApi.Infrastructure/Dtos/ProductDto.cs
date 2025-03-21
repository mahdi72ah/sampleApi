using System;
using System.Collections.Generic;
using System.Text;

namespace sampleApi.Infrastructure.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? PriceWithComma { get; set; }
        public long Price { get; set; }
        // اضافه کردن فیلد جدید برای ترکیب Name و Price
        public string CombinedInfo => $"{ProductName} {Price}";
    }
}
