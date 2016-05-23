using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MaisonDesLigues
{
    class News
    {
        public News()
        {

        }
        public void envoyerEmail(String titre, String content)
        {
            MailMessage email = new MailMessage();
            /*
            email.From = tbExpediteur.Text;
            email.To = tbDestinataire.Text;
            email.Subject = tbObjet.Text;
            email.Body = tbMessage.Text;
            */
        }
    
    }
}
