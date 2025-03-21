using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sampleApi.Core.Entities;

// تعریف کلاس تنظیمات برای جدول Product
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // تنظیم نام جدول
        builder.ToTable("Product");

        // تنظیم ستون Id به عنوان کلید اصلی
        builder.HasKey(p => p.Id);

        // تنظیم ستون Title به عنوان مقدار مورد نیاز با حداکثر طول 100 کاراکتر
        builder.Property(p => p.ProductName)
            .IsRequired() // مقدار ضروری
            .HasMaxLength(100); // حداکثر طول

        // تنظیم ستون Price به عنوان مقدار ضروری
        builder.Property(p => p.Price)
            .IsRequired(); // مقدار ضروری
    }
}