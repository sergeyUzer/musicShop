namespace Shop.BLL.Utils
{
    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using NLog;

    /// <summary>
    /// Class for sending mail
    /// </summary>
    public static class MailDispatch
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// From the email you are sending
        /// </summary>
        private static string _emailOfSendr = "q1music-shop@yandex.ru";

        /// <summary>
        /// Sendr name
        /// </summary>
        private static string _nameOfSendr = "Music Shop";

        /// <summary>
        /// Password from the box
        /// </summary>
        private static string _passwordBox = "f,kznjuhfa";

        /// <summary>
        /// SMTP client address
        /// </summary>
        private static string _smtpClient = "smtp.yandex.ru";

        /// <summary>
        /// Port for SMTP
        /// </summary>
        private static int _smtpPort = 587;

        /// <summary>
        /// Sends a message to the address usetEmail
        /// </summary>
        /// <param name="userEmail">Recipient's email</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <returns></returns>
        public static bool SendingMail(string userEmail, string subject, string body)
        {
            var smtp = ConfigureSmtpClient();
            var message = ConfigureMailMessage(userEmail, subject, body);

            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Warn($"Проблема при отправке письма пользователю\r\n{ex}");
                return false;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static async Task<bool> SendingMailAsync(string userEmail, string subject, string body)
        {
            var smtp = ConfigureSmtpClient();
            var message = ConfigureMailMessage(userEmail, subject, body);

            try
            {
                await smtp.SendMailAsync(message).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Warn($"Проблема при отправке письма пользователю\r\n{ex}");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private static SmtpClient ConfigureSmtpClient()
        {
            SmtpClient smtp = new SmtpClient(_smtpClient, _smtpPort);
            smtp.Credentials = new System.Net.NetworkCredential(_emailOfSendr, _passwordBox);

            // Use SSH Encryption
            smtp.EnableSsl = true;

            return smtp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private static MailMessage ConfigureMailMessage(string userEmail, string subject, string body)
        {
            if (userEmail == null)
            {
                throw new ArgumentException("userEmail");
            }

            if (subject == null)
            {
                throw new ArgumentException("subject");
            }

            if (body == null)
            {
                throw new ArgumentException("body");
            }

            MailAddress from = new MailAddress(_emailOfSendr, _nameOfSendr);

            MailAddress to = new MailAddress(userEmail);

            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            message.Body = string.Format(body);
            message.IsBodyHtml = true;

            return message;
        }
    }
}
