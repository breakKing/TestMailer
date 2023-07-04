using TestMailer.Application.Mailing;
using TestMailer.Domain.Mailing;

namespace TestMailer.Infrastructure.Persistence.Repositories;

/// <inheritdoc />
internal sealed class EmailWriteRepository : IEmailWriteRepository
{
    private readonly MailingDbContext _context;

    public EmailWriteRepository(MailingDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public void Add(Email email)
    {
        _context.Set<Email>().Add(email);
    }
}