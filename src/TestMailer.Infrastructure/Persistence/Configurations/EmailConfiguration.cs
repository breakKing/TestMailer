using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestMailer.Domain.Mailing;

namespace TestMailer.Infrastructure.Persistence.Configurations;

internal sealed class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("email", "Mailing");

        builder.Property(e => e.Subject)
            .HasMaxLength(150)
            .HasComment("Тема письма");

        builder.Property(e => e.Body)
            .HasComment("Тело письма");

        builder.Property("_recipients")
            .HasColumnName("recipients")
            .HasColumnType("text[]")
            .HasComment("Получатели");

        builder.Ignore(e => e.Recipients);

        builder.Property(e => e.CreatedAt)
            .HasComment("Дата создания и отправки");

        builder.Property(e => e.Result)
            .HasComment("Результат отправки");
        
        builder.Property(e => e.FailedMessage)
            .HasMaxLength(500)
            .HasComment("Описание ошибки при отправке (если есть)")
            .IsRequired(false);

        builder.HasIndex(e => e.Subject);
    }
}