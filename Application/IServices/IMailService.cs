using Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IMailService
    {
        public Task SendEmailAsync(EmailRequest emailRequest);
        public Task SendConFirmEmailAsync(EmailRequest emailRequest);
    }
}
