using BussinessLogicLayer.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BussinessLogicLayer.Services
{
    public class UserEmail : IUserEmail
    {
        private readonly IConfiguration configuration;

        public UserEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(string toemail, string subject, string body)
        {
            string Host = configuration["SmtpSettings:Host"];
            string port = configuration["SmtpSettings:Port"];
            string username = configuration["SmtpSettings:UserName"];
            string password = configuration["SmtpSettings:Password"];

            //smtpclient
            var smtp = new SmtpClient(Host, int.Parse(port));

            //network Credential
            smtp.Credentials= new NetworkCredential(username, password);
            //ssl-where the communication is encrypted between application and gmail where others cannot see
            smtp.EnableSsl = true;
            var message=new MailMessage(username,toemail,subject,body);
            message.IsBodyHtml = true;


            await smtp.SendMailAsync(message);
        }
    } 
}
