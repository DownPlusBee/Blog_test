using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.Configuration
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("BlogPost");

            builder.Property(e => e.CreatedDate).HasColumnType("date");
        }

        public void Configure(EntityTypeBuilder<BlogPostContent> builder)
        {
            builder.ToTable("BlogPostContent");
            builder.Property(e => e.Body)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength(true);

            builder.Property(e => e.ModifiedDate).HasColumnType("date");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.BlogPost)
                .WithMany(p => p.BlogPostContents)
                .HasForeignKey(d => d.BlogPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogPostContents_BlogPost");
        }

        public void Configure(EntityTypeBuilder<BlogPostRemoved> builder)
        {
            builder.ToTable("BlogPostRemoved");
            builder.ToTable("BlogPostRemoved");

            builder.Property(e => e.RemovedDate).HasColumnType("date");

            builder.HasOne(d => d.BlogPost)
                .WithMany(p => p.BlogPostRemoveds)
                .HasForeignKey(d => d.BlogPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogPostRemoved_BlogPost");
        }
    }
}
