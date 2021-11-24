using NorthWind.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace NorthWind.Sales.Mail
{
    public class MailService : IMailService
    {
        readonly IApplicationStatusLogger _logger;
        public MailService(IApplicationStatusLogger logger)
            => _logger = logger;

        public Task Send(string message)
        {
            _logger.Log($"*** MailService: {message}");
            _logger.Log($"*** MailService: Servidor de correo no configurado ***");

            return Task.CompletedTask;

        }
    }
}
