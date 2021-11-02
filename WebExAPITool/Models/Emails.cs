using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models
{
    public class Emails
    {

        private string _fromEmail = string.Empty;
        private string _fromEmailPassword = string.Empty;
        private string _toEmail = string.Empty;
        private string _smtp = string.Empty;
        private string _domain = string.Empty;
        private string _smtpPort = string.Empty;
        private readonly IConfiguration _Config;
        public Emails(WebExDBContext context, IConfiguration config)
        {
            _Config = config;
        }

        public bool SendEmail(string emailBody, string emailSubject, string orgName)
        {
            try
            {
                // Get the email sending Details 
                _fromEmailPassword = _Config.GetSection("EmailSettings").GetValue<string>("fromPassword");
                _toEmail = _Config.GetSection("EmailSettings").GetValue<string>("to");
                _smtp = _Config.GetSection("EmailSettings").GetValue<string>("smtp");
                _smtpPort = _Config.GetSection("EmailSettings").GetValue<string>("smtpport");
                _domain = _Config.GetSection("EmailSettings").GetValue<string>("domain");
                _fromEmail = _Config.GetSection("EmailSettings").GetValue<string>("from");

                if (!(string.IsNullOrEmpty(_fromEmail)))
                {
                    

                    _fromEmail = _fromEmail.Replace("{{orgname}}", orgName);
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress(_fromEmail);
                    var splitEmails = _toEmail.Split(";");
                    foreach (var item in splitEmails)
                    {
                       message.To.Add(new MailAddress(item));
                    }

                    message.Subject = emailSubject;
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body = emailBody;
                    smtp.Port = Int32.Parse(_smtpPort);
                    smtp.Host = _smtp;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = true;
                    //smtp.Credentials = new NetworkCredential(_fromEmail, _fromEmailPassword);
                    smtp.Timeout = 600000;
                    smtp.Send(message);

                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
