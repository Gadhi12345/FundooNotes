using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BussinessLogicLayer.Interface
{
    public interface IUserEmail
    {
        Task SendEmail(string toemail,string subject,string body);
    }
}
