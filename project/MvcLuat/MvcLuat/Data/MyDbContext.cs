using Microsoft.EntityFrameworkCore;
using MvcLuat.Models;
using System.Xml;


namespace MvcLuat.Data
{
    public class MyDbContext : DbContext
    {
        internal IEnumerable<object> User;

        public MyDbContext(DbContextOptions<MyDbContext> option, IEnumerable<object> user) : base(option)
        {
            User = user;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Section> Sections { get; set; }


        // Thêm các DbSet cho các bảng khác (nếu có)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình thêm (nếu cần)
            modelBuilder.Entity<Article>()
            .HasOne(o => o.Chapter)
            .WithMany(u => u.Articles)
            .HasForeignKey(o => o.ChapterID);

            modelBuilder.Entity<Section>()
            .HasOne(o => o.Article)
            .WithMany(u => u.Sections)
            .HasForeignKey(o => o.ArticleID);
        }
    }
}
