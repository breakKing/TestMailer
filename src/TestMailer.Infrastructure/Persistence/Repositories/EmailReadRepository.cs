using Microsoft.EntityFrameworkCore;
using TestMailer.Application.Mailing;
using TestMailer.Application.Mailing.GetEmails;
using TestMailer.Domain.Mailing;

namespace TestMailer.Infrastructure.Persistence.Repositories;

/// <inheritdoc />
internal sealed class EmailReadRepository : IEmailReadRepository
{
    private readonly MailingDbContext _context;

    public EmailReadRepository(MailingDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public Task<List<EmailItemDto>> GetListAsync(CancellationToken ct = default)
    {
        var query = _context.Set<Email>()
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new EmailItemDto(
                e.Subject,
                e.Body,
                EF.Property<List<string>>(e, "_recipients"),
                e.CreatedAt,
                e.Result,
                e.FailedMessage))
            .AsNoTracking();
        
        return query.ToListAsync(ct);
    }
}