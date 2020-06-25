using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailServiceApi.Interfaces
{

    public class EmailServices : IEmailServices
    {



        public async Task<Response>Send(string apiKey, string to, string cc, string subject, string message)
        {
             apiKey = Environment.GetEnvironmentVariable("SendGrid_ApiKey");
            //string str = "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";
             var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("sijuadebabs@gmail.com", "Benignus Okorie"),
                Subject = subject,
              //  PlainTextContent = message,
               // HtmlContent = message
                
            };
            msg.AddContent(MimeType.Text, message);
            msg.AddTo(to);
            msg.AddCc(cc);
           
           
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response;
        }

        public Task<Response> SendEmail(string to, string cc, string subject, string message)
        {

            return Send(Environment.GetEnvironmentVariable("SendGrid_ApiKey"), to, cc,  subject, message);
        }
    }
}
