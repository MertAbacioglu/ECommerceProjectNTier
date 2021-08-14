﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public static class MailSender
    {
        public static void Send(string receiver,string password="34243424",string body="Test Mesajıdır",string subject = "E-Mail Testi",string sender = "yms34243423@gmail.com")
        {
            MailAddress senderMail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port=587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderMail.Address,password)
            };


            using(MailMessage message = new MailMessage(senderMail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }


        }


    }
}
