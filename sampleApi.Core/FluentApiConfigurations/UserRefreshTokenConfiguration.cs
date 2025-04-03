using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sampleApi.Core.Entities;

namespace sampleApi.Core.FluentApiConfigurations
{
    public class UserRefreshTokenConfiguration:IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            // تنظیم نام جدول
            builder.ToTable("UserRefreshToken");

            // تنظیم ستون Id به عنوان کلید اصلی
            builder.HasKey(p => p.Id);

            // تنظیم ستون Title به عنوان مقدار مورد نیاز با حداکثر طول 100 کاراکتر
            builder.Property(p => p.RefreshToken)
                .IsRequired() // مقدار ضروری
                .HasMaxLength(500); // حداکثر طول
        }
    }
}
