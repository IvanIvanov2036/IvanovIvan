using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanovIvan.UsersClasses
{
    public class InfoEmailSending
    {
        public InfoEmailSending(string smtpClientAddress, StringPair emailAddressFrom, string emailPassword,
                    StringPair emailAddressTo,
                    string subject, string body)
        {

            SmtpClientAddress = !string.IsNullOrWhiteSpace(smtpClientAddress) ? smtpClientAddress : throw new ArgumentNullException(errorMessage);
            EmailPassword = !string.IsNullOrWhiteSpace(emailPassword) ? emailPassword : throw new ArgumentNullException(errorMessage);

            EmailAddressFrom = emailAddressFrom ?? throw new ArgumentNullException(nameof(errorMessage));
            EmailAddressTo = emailAddressTo ?? throw new ArgumentNullException(nameof(errorMessage));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }
        public string SmtpClientAddress { get; set; }
        public StringPair EmailAddressFrom { get; set; }
        public string EmailPassword { get; set; }
        public StringPair EmailAddressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        private string errorMessage = "Нельзя вставлять пробелы или пустое значение!";
    }
}
