using System;
using System.IO;
using System.Net.Mail;

namespace Library
{
    public class Emails
    {
        /// <summary>
        /// A simple class to store information about an email message.
        /// </summary>
        /// 
        public class Message
        {
            public string From { get; set; }

            public string To { get; set; }

            public string CC { get; set; }

            public string BCC { get; set; }

            public string Subject { get; set; }

            public string Body { get; set; }




            public Message(string From, string To, string Subject, string Body, string CC, string BCC)
            {
                this.From    = From;
                this.To      = To;
                this.CC      = CC;
                this.BCC     = BCC;
                this.Subject = Subject;
                this.Body    = Body;
            }
        }

        /// <summary>
        /// A simple class to store information about an email server.
        /// </summary>
        /// 
        public class Server
        {
            public string Name { get; set; }

            public int Port { get; set; }

            public bool EnableSSL { get; set; }

            public string User { get; set; }

            public string Password { get; set; }




            public Server(string Name, int Port, bool EnableSSL, string User, string Password)
            {
                this.Name      = Name;
                this.Port      = Port;
                this.EnableSSL = EnableSSL;
                this.User      = User;
                this.Password  = Password;
            }
        }




        private static string _errorMessage = "";

        /// <summary>
        /// Gets the error message if a method returns false.
        /// </summary>
        /// 
        public static string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            private set
            {
                if (value != null)
                {
                    _errorMessage = value;
                }
            }
        }




        /// <summary>
        /// Sends a plain text email.
        /// </summary>
        /// 
        /// <param name="MessageSettings">
        /// Contains information about the email including to address, from address, subject text and body text.
        /// </param>
        /// 
        /// <param name="ServerSettings">
        /// Contains information about the email server.
        /// </param>
        /// 
        /// <returns>
        /// True if the email was sent successfully.
        /// </returns>
        /// 
        public static bool SendEmail(Emails.Message MessageSettings, Emails.Server ServerSettings)
        {
            return SendEmailWithAttachment(MessageSettings, "", ServerSettings);
        }

        /// <summary>
        /// Sends a plain text email with an attached file.
        /// </summary>
        /// 
        /// <param name="MessageSettings">
        /// Contains information about the email including to address, from address, subject text and body text.
        /// </param>
        /// 
        /// <param name="AttachmentPath">
        /// The full name and path to the file that is to be attached.
        /// </param>
        /// 
        /// <param name="ServerSettings">
        /// Contains information about the email server.
        /// </param>
        /// 
        /// <returns>
        /// True if the email was sent successfully.
        /// </returns>
        /// 
        public static bool SendEmailWithAttachment(Emails.Message MessageSettings, string AttachmentPath, Emails.Server ServerSettings)
        {
            Attachment attachment = null;
            if (!string.IsNullOrEmpty(AttachmentPath) && File.Exists(AttachmentPath))
            {
                attachment = new Attachment(AttachmentPath);
            }

            return SendEmailWithAttachment(MessageSettings, attachment, ServerSettings);
        }

        /// <summary>
        /// Sends a plain text email with an attached file.
        /// </summary>
        /// 
        /// <param name="MessageSettings">
        /// Contains information about the email including to address, from address, subject text and body text.
        /// </param>
        /// 
        /// <param name="EmailAttachment">
        /// The file contents of the attachment for the email.
        /// </param>
        /// 
        /// <param name="ServerSettings">
        /// Contains information about the email server.
        /// </param>
        /// 
        /// <returns>
        /// True if the email was sent successfully.
        /// </returns>
        /// 
        public static bool SendEmailWithAttachment(Emails.Message MessageSettings, Attachment EmailAttachment, Emails.Server ServerSettings)
        {
            bool emailSent = false;

            if (!string.IsNullOrEmpty(MessageSettings.From))
            {
                if (!string.IsNullOrEmpty(MessageSettings.To))
                {
                    if (!string.IsNullOrEmpty(MessageSettings.Body))
                    {
                        //  Set up the server first.

                        var smtpServer = new SmtpClient(ServerSettings.Name)
                        {
                            Port      = ServerSettings.Port,
                            EnableSsl = ServerSettings.EnableSSL
                        };

                        //  Add credentials only if a user has been specified.

                        if (!string.IsNullOrEmpty(ServerSettings.User))
                        {
                            smtpServer.Credentials = new System.Net.NetworkCredential(ServerSettings.User, ServerSettings.Password);
                        }

                        //  Set up the email message.

                        var mail = new MailMessage
                        {
                            IsBodyHtml = false,
                            From       = new MailAddress(MessageSettings.From),
                            Subject    = MessageSettings.Subject,
                            Body       = MessageSettings.Body
                        };
                        mail.To.Add(MessageSettings.To);

                        if (!string.IsNullOrEmpty(MessageSettings.CC))
                        {
                            mail.CC.Add(MessageSettings.CC);
                        }
                        if (!string.IsNullOrEmpty(MessageSettings.BCC))
                        {
                            mail.Bcc.Add(MessageSettings.BCC);
                        }

                        if (EmailAttachment != null)
                        {
                            mail.Attachments.Add(EmailAttachment);
                        }

                        //  Send the email message.

                        try
                        {
                            smtpServer.Send(mail);
                            emailSent = true;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            ErrorMessage = "To field did not contain a recipient.";
                        }
                        catch (SmtpFailedRecipientsException failedEx)
                        {
                            ErrorMessage = "Email could not be delivered.  " + failedEx.Message;
                        }
                        catch (SmtpException smtpEx)
                        {
                            ErrorMessage = smtpEx.ToString();
                        }
                    }
                    else
                    {
                        ErrorMessage = "Body of email cannot be empty for email messages.";
                    }
                }
                else
                {
                    ErrorMessage = "To field cannot be empty for email messages.";
                }
            }
            else
            {
                ErrorMessage = "From field cannot be empty for email messages.";
            }

            return emailSent;
        }
    }
}