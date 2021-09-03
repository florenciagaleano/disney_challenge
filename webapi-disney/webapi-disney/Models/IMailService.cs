using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDisney.Models
{
    public interface IMailService
    {
        Task SendMail(string mail, string subject, string htmlContent);
    }
}
