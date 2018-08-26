
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EmailFunction
    {
        private DrivingSchoolEntities db = new DrivingSchoolEntities();
     public void SendMail(string ToEmail, string OrderID , decimal Total)
        {
            var emailCred = db.CompanyEmails.SingleOrDefault();

            MailMessage mail = new MailMessage(emailCred.EmailAddress, ToEmail, "Sahana Distributers | Email Receipt for Order ID "+ OrderID + "", "<b>Thank you for dealing with Sahana Distributors!</b> \n TOTAL FARE : RS "+Total+ " \n We will inform you that whether the order confirmed");

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(emailCred.EmailAddress, emailCred.Password);

            client.EnableSsl = true;
            client.Send(mail);

        }


        public void SendMailConfirm(string ToEmail, string OrderID, string status)
        {
            var emailCred = db.CompanyEmails.SingleOrDefault();

            MailMessage mail = new MailMessage(emailCred.EmailAddress, ToEmail, "Sahana Distributers | Email Receipt for Order ID " + OrderID + "", "<b>Thank you for dealing with Sahana Distributors!</b> \n  \n Your Order "+status+"");

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(emailCred.EmailAddress, emailCred.Password);

            client.EnableSsl = true;
            client.Send(mail);

        }
    }
}