using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sampleApi.Core.Entities;

namespace sampleApi.Core.FluentApiConfigurations
{
    public class UsersConfiguration: IEntityTypeConfiguration<Users>
    {
        private IEntityTypeConfiguration<Users> _entityTypeConfigurationImplementation;
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            // تنظیم نام جدول
            builder.ToTable("Users");

            // تنظیم ستون Id به عنوان کلید اصلی
            builder.HasKey(p => p.Id);

            // تنظیم ستون UserName به عنوان مقدار مورد نیاز با حداکثر طول 100 کاراکتر
            builder.Property(p => p.UserName)
                .IsRequired() // مقدار ضروری
                .HasMaxLength(100); // حداکثر طول

            // تنظیم ستون Passsword به عنوان مقدار ضروری
            builder.Property(p => p.Passsword)
                .IsRequired(); // مقدار ضروری
        }
    }
}
