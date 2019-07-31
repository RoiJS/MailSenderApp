using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MailSenderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailSender = new MailSender();
            mailSender.Send("amatongroi@gmail.com", "This is a sample subject", "<span><b>Hello world</b></span>");
            //mailSender.Send("Roi.Amatong@qlogic.se", "This is a sample subject", "<span><b>Hello world</b></span>");
        }
    }

    public class MailSender
    {

        public void Send(String receiverEmail, String subject, String htmlBody)
        {
            var smtp = "smtp.gmail.com";
            string senderEmail = "amatongroi@gmail.com";
            string senderP = "september9152011";
            string senderDisplayName = "Roi Larrence";
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                MailAddress fromAddress = new MailAddress(senderEmail, senderDisplayName);
                mail.From = fromAddress;
                mail.To.Add(receiverEmail);
                mail.Subject = subject;
                mail.Body = htmlBody;
                SmtpClient smtpClient = new SmtpClient(smtp);
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderP);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
