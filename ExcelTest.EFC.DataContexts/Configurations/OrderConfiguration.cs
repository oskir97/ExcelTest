using ExcelTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.EFC.DataContexts.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Customer)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(p => p.Freight)
                .IsRequired();
            builder.Property(p => p.Country)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
