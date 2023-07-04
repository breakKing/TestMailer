using Microsoft.EntityFrameworkCore;
using TestMailer.Application.Common.DataAccess;

namespace TestMailer.Infrastructure.Persistence;

internal sealed class MailingDbContext : DbContext, IUnitOfWork
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