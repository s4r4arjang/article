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
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content);
            builder.HasOne(p => p.Category).WithMany(p => p.Articles).HasForeignKey(p => p.CategoryId);
        }
    }
}
