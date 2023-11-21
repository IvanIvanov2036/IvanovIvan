using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IvanovIvan.UsersClasses
{
    internal class SendingEmail
    {
        private InfoEmailSending InfoEmailSending {  get; set; }
        public SendingEmail(InfoEmailSending infoEmailSending)
        {
            InfoEmailSending = infoEmailSending
            ?? throw new ArgumentNullException(nameof(infoEmailSending));
        }
        public void Send()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(InfoEmailSending.SmtpClientAddress);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.EnableSsl = true;

                NetworkCredential basicAuthentificationInfo = new NetworkCredential(InfoEmailSending.EmailAddressFrom.EmailAdress, InfoEmailSending.EmailPassword);
                smtpClient.Credentials = basicAuthentificationInfo;
                MailAddress from = new MailAddress(InfoEmailSending.EmailAddressFrom.EmailAdress, InfoEmailSending.EmailAddressFrom.Name);
                MailAddress to = new MailAddress(InfoEmailSending.EmailAddressFrom.EmailAdress, InfoEmailSending.EmailAddressFrom.Name);
                MailMessage myMail = new MailMessage(from, to);
                MailAddress replyTo = new MailAddress(InfoEmailSending.EmailAddressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);
                Encoding encoding = Encoding.UTF8;
                myMail.Subject = InfoEmailSending.Subject;
                myMail.SubjectEncoding = encoding;
                myMail.Body = InfoEmailSending.Body;
                myMail.BodyEncoding = encoding;
                smtpClient.Send(myMail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
