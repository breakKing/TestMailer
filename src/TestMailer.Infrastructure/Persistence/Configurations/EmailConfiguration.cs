using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestMailer.Domain.Mailing;

namespace TestMailer.Infrastructure.Persistence.Configurations;

public sealed class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("email", "mailing");

        builder.Property(e => e.Subject)
            .HasMaxLength(150);

        builder.Property("_recipients")
            .HasColumnType("text[]");

        builder.Ignore(e => e.Recipients);

        builder.Property(e => e.FailedMessage)
            .HasMaxLength(500);

        builder.HasIndex(e => e.Subject);
    }
}