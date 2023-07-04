using System.ComponentModel.DataAnnotations;

namespace TestMailer.Infrastructure.Emailing;

/// <summary>
/// Конфигурация подключения к SMTP-серверу
/// </summary>
internal sealed class SmtpConfiguration
{
    /// <summary>
    /// Название секции в разделе конфигурации
    /// </summary>
    public const string SectionName = "Smtp";

    [Required]
    public string Host { get; set; } = null!;
    
    [Required]
    public int Port { get; set; }
    
    [Required]
    public string UserName { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
    
    [Required]
    public bool UseSsl { get; set; }
    
    [Required]
    public bool UseStartTls { get; set; }
    
    [Required]
    public string DisplayName { get; set; } = null!;
    
    [Required]
    public string From { get; set; } = null!;
}