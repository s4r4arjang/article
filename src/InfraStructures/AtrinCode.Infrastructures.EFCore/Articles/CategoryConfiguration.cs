using AtrinCode.Core.Domain.Articles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Infrastructures.EFCore.Articles
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {   builder.HasKey(s=>s.Id); 
            builder.Property(s=>s.Title).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Article>()
            //    .HasOne(p => p.articleCategory)
            //    .WithMany(b => b.articles).HasForeignKey(p => p.CategoryId);
            //throw new NotImplementedException();
          //  builder.HasMany(p => p.Articles).WithOne(p => p.Category).HasForeignKey(s=>s.CategoryId);
        }
    }
}
