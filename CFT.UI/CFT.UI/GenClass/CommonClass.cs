using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace CFT.UI.GenClass
{
    public class CommonClass
    {
        public void SendMail(string customerName,string product)
        {
            try
            {
                string html = string.Empty;
                html = ConvertHtml(customerName, product);
                SendGmail("Admin", "testingmotifworks@gmail.com", "rakeshchandrasekar@gmail.com", "Testing Email", html);
            }
            catch (Exception ex)
            {

            }
        }

        private void SendGmail(string senderName, string senderEmail, string receiverEmails, string subject,
                                 string html)
        {
            try
            {
                String APIKey = senderEmail;
                String SecretKey = "Motif@123";
                String From = senderEmail;
                String To = receiverEmails;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(From, "Motifworks");
                msg.To.Add(new MailAddress(To));
                msg.Body = html;
                msg.Subject = subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(APIKey, SecretKey);

                client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string ConvertHtml(string customerName, string product)
        {
            string html = @"<p>&nbsp; &nbsp;</p>"
+ "<table style=\"border-color: #000000; border-width: 10px; border-style: solid;\"" + " border=\"0\"" + ">"
    + "<tbody>"
        + "<tr>"
            + "<td><img title=\"Thermofisher\"" + " src=\"http://www.impactlearning.com/wp-content/uploads/thermo-fisher1.jpg\"" + " alt=\"\"" + " width=\"100\"" + " height=\"51\"" + " />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>"
            + "<td>&nbsp;</td>"
        + "</tr>"
        + "<tr>"
            + "<td>"
                + "<p>&nbsp;</p>"
                + "<p>Dear <strong>" + customerName.Trim() + "</strong>,</p>"
                + "<p>Now that you have had a chance to evaliate our <strong>" + product.Trim() + "</strong>, we would like to hear from you! The Total satisfaction of our customers, even after their purchase, is extremely important to us.</p>"
                + "<p>Won't you take a moment to fill out the enclosed questionnaire? <strong>ThermoFisher</strong> knows that it is our customers who make our business. We therefore want to make sure that the purchase of a <strong>" + product.Trim() + "</strong> is a satisfying experience for all.</p>"
                + "<p>We greatly appreciate your response to this questionnaire. Should you require any immediate assitance, or would prefer to respond by telephone, please feel to contact us at <strong>1800-000-0000</strong> between 8am to 8pm. I would welcome any comments you may have.</p>"
                + "<p><a title=\"Feedback\"" + " href=\"http://www.test.com/ProductInfo/FeedbackPage?validatekey=1234567890\"" + ">Click here to start the Feedback.</a></p>"
                + "<p>Regards<br />Survey Team</p>"
                + "<p></p>"
            + "</td>"
            + "<td>&nbsp;</td>"
        + "</tr>"
    + "</tbody>"
+ "</table>";

            return html;
        }
    }
}