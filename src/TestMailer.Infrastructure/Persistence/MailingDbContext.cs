using Microsoft.EntityFrameworkCore;

namespace TestMailer.Infrastructure.Persistence;

public sealed class MailingDbContext : DbContext
{
    /// <inheritdoc />
    public MailingDbContext(DbContextOptions options) : base(options)
    {
        
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MailingDbContext).Assembly);
    }
}