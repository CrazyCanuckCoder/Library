#region

using System;
using System.IO;
using System.Net.Mail;

#endregion

namespace Library
{
    public class Emails
    {
        private static string _errorMessage = "";

        public static string ErrorMessage
        {
            get { return _errorMessage; }

            private set
            {
                if (value != null)
                {
                    _errorMessage = value;
                }
            }
        }

        public static bool SendEmail(string From, string To, string Subject, string Body, string EmailServer, int EmailPort,
                                                   bool EmailEnableSSL, string EmailUser, string EmailPassword)
        {
            return SendEmailWithAttachment(From, To, Subject, Body, "", EmailServer, EmailPort, EmailEnableSSL, EmailUser, EmailPassword);
        }

        public static bool SendEmailWithAttachment(string From, string To, string Subject, string Body,
                                                   string AttachmentPath, string EmailServer, int EmailPort,
                                                   bool EmailEnableSSL, string EmailUser, string EmailPassword)
        {
            Attachment attachment = null;
            if (File.Exists(AttachmentPath))
            {
                attachment = new Attachment(AttachmentPath);
            }

            return SendEmailWithAttachment(From, To, Subject, Body, attachment, EmailServer, EmailPort, EmailEnableSSL, EmailUser, EmailPassword);
        }

        public static bool SendEmailWithAttachment(string From, string To, string Subject, string Body,
                                                   Attachment EmailAttachment, string EmailServer, int EmailPort,
                                                   bool EmailEnableSSL, string EmailUser, string EmailPassword)
        {
            bool emailSent = false;

            if (!From.IsEmpty())
            {
                if (!To.IsEmpty())
                {
                    if (!Body.IsEmpty())
                    {
                        var smtpServer = new SmtpClient(EmailServer)
                        {
                            Port = EmailPort,
                            EnableSsl = EmailEnableSSL
                        };

                        //  Add credentials only if a user has been specified.

                        if (!string.IsNullOrEmpty(EmailUser))
                        {
                            smtpServer.Credentials = new System.Net.NetworkCredential(EmailUser, EmailPassword);
                        }

                        var mail = new MailMessage
                        {
                            IsBodyHtml = false,
                            From = new MailAddress(From),
                            Subject = Subject,
                            Body = Body
                        };
                        mail.To.Add(To);

                        if (EmailAttachment != null)
                        {
                            mail.Attachments.Add(EmailAttachment);
                        }

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