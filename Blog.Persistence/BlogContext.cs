using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Persistence
{
    public partial class BlogContext : DbContext
    {
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<BlogPostContent> BlogPostContents { get; set; }
        public virtual DbSet<BlogPostRemoved> BlogPostRemoveds { get; set; }


        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);

            //modelBuilder.Entity<BlogPost>().HasData(
            //    new BlogPost { Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"), Title = "A", Body = "K", CreatedBy = "12345678", CreatedDate = DateTime.Now },
            //    new BlogPost { Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"), Title = "B", Body = "L", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-2) },
            //    new BlogPost { Id = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"), Title = "C", Body = "M", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-3) },
            //    new BlogPost { Id = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"), Title = "D", Body = "N", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-4) },
            //    new BlogPost { Id = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"), Title = "E", Body = "O", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-5) },
            //    new BlogPost { Id = Guid.Parse("{77E8F72F-B2F0-4819-9B4F-B0DC991304F7}"), Title = "F", Body = "P", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-6) },
            //    new BlogPost { Id = Guid.Parse("{BA7B552F-71BF-4F7A-B4DA-CFA66C29B651}"), Title = "G", Body = "Q", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-7) },
            //    new BlogPost { Id = Guid.Parse("{35B80EEB-26DB-4142-B948-E67C0E87A99A}"), Title = "H", Body = "R", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-8) },
            //    new BlogPost { Id = Guid.Parse("{4FFE6FC6-183D-468A-B3E5-01D2020C87E0}"), Title = "I", Body = "S", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-9) },
            //    new BlogPost { Id = Guid.Parse("{6429AE3C-E84F-4BCF-8C47-09969ED7C83A}"), Title = "J", Body = "T", CreatedBy = "12345678", CreatedDate = DateTime.Now.AddDays(-10) });

            OnModelCreatingPartial(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries<BlogPost>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedDate = DateTime.Now;
            //            entry.Entity.Id = Guid.NewGuid();
            //            break;

            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedDate = DateTime.Now;
            //            break;
            //    }
            //}
            return base.SaveChangesAsync(cancellationToken);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
