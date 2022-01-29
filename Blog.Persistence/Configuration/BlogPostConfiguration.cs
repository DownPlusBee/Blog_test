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

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Body)
                .IsRequired()
                .HasMaxLength(600)
                .IsUnicode(false);

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength(true);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");

        }
    }
}
