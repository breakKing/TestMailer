using Microsoft.EntityFrameworkCore;
using TestMailer.Application.Mailing;
using TestMailer.Application.Mailing.GetEmails;
using TestMailer.Domain.Mailing;

namespace TestMailer.Infrastructure.Persistence.Repositories;

/// <inheritdoc />
public sealed class EmailReadRepository : IEmailReadRepository
{
    private readonly MailingDbContext _context;

    public EmailReadRepository(MailingDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public Task<List<EmailItemDto>> GetListAsync(CancellationToken ct = default)
    {
        return _context.Set<Email>()
            .Select(e => new EmailItemDto(
                e.Subject, 
                e.Body, 
                e.Recipients.ToList()))
            .ToListAsync(ct);
    }
}