using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailServiceApi.Interfaces
{
    public interface IEmailServices
    {
        
        Task<Response> SendEmail(string to, string cc, string subject, string message);
    }

    

}
