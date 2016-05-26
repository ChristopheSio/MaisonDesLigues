using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;

namespace MaisonDesLigues
{
    static class Logs
    {

        public static void enregistrerLog(String titre, String content)
        {
            // Append line to the file.
            using (StreamWriter writer = new StreamWriter(fileLog, true))
            {
                writer.WriteLine("--"+ titre+ "--");
                writer.WriteLine(content);
                writer.WriteLine("----------------\r\n\r\n\r\n");
            }

        }

        public static string envoyerEmail(String titre, String content, MailAddress from, MailAddress to)
        {
            string status = "Not Send";
            try
            {
                SmtpClient mySmtpClient = new SmtpClient(emailSmtp);

                /*
                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("username", "password");
                mySmtpClient.Credentials = basicAuthenticationInfo;
                */

                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);
                // set subject and encoding
                myMail.Subject = titre;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;
                // set body-message and encoding
                myMail.Body = content;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = false;
                //
                mySmtpClient.Send(myMail);
                status = "Send";
            }
            catch (SmtpException ex) {
                status = "Error, SmtpException has occured: " + ex.Message;
            }
            catch (Exception ex) {
                status = "Error, " + ex.Message;
            }

            using (StreamWriter writer = new StreamWriter(emailFileLog, true))
            {
                writer.WriteLine("--" + titre + "--");
                writer.WriteLine("-- Status mail = " + status + "--");
                writer.WriteLine(content);
                writer.WriteLine("----------------\r\n\r\n\r\n");
            }

            return status;
        }

        static string fileLog = "journal.txt";
        static string emailFileLog = "journal_email.txt";
        static string emailSmtp = "smtp.comcast.net";
    }
}


/*
// add from,to mailaddresses
MailAddress from = new MailAddress("test@example.com", "TestFromName");
MailAddress to = new MailAddress("test2@example.com", "TestToName");
    */