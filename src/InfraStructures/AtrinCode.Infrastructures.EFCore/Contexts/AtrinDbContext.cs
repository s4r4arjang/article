using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtrinCode.Core.Domain.Articles.Entities;
using AtrinCode.Infrastructures.EFCore.Articles;
using Microsoft.EntityFrameworkCore;

namespace AtrinCode.Infrastructures.EFCore.Contexts
{
    public class AtrinDbContext : DbContext
    {
        public AtrinDbContext(DbContextOptions<AtrinDbContext> options)
        : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FileTable> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            //modelBuilder.Entity<Article>().Property(b => b.CreatorId)
            //.HasDefaultValueSql("1");
        }
    }
}
