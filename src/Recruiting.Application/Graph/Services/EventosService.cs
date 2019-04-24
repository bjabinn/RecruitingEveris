using Recruiting.Application.Graph.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Recruiting.Application.Graph.Services
{
    public class EventosService : IEventosService
    {
        #region Fields

        //Pasar al fichero de configuracion
        private readonly int _ClientPort = 25;
        private readonly string _ClientHost = "10.108.22.43";

        #endregion

        #region Constructor

        #endregion

        #region EventosService members

        public void EnviarCitas(EventoRowViewModel eventoParaEnviar)
        {
            try
            {
                var mail = FormatoEvento(
                                "REQUEST"
                                ,eventoParaEnviar.Destinatarios
                                ,eventoParaEnviar.Inicio
                                ,eventoParaEnviar.Fin
                                ,eventoParaEnviar.Body
                                ,eventoParaEnviar.Asunto
                                ,eventoParaEnviar.Localizacion
                                ,eventoParaEnviar.identificador
                                ,eventoParaEnviar.From

                                );

          
                
                SendEmail(mail);
                               
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }
        #endregion

        #region Private methods

        private MailMessage FormatoEvento(string status, List<string> receiverEmails, DateTime eventStart, DateTime eventEnd, string body, string subject, string location, Guid identifier, string from)
        {
            string method = "";
            switch (status)
            {
                case "REQUEST":
                    method = "METHOD:REQUEST";
                    break;
                case "CANCEL":
                    method = "METHOD:CANCEL";
                    break;
                default:
                    method = "METHOD:REQUEST";
                    break;
            }

            // Contruct the ICS file using string builder
            MailMessage m = new MailMessage();
            m.From = new MailAddress(from, "from");
            foreach (var to in receiverEmails)
            {
                m.To.Add(new MailAddress(to, to.Substring(0, to.IndexOf("@"))));
            }
            m.Subject = subject;
            m.Body = body;
            StringBuilder str = new StringBuilder();
            
            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//Schedule a Meeting");
            str.AppendLine("VERSION:2.0");
            str.AppendLine(method);
            str.AppendLine("BEGIN:VEVENT");
            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", eventStart));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", eventEnd));
            str.AppendLine("LOCATION: " + location);
            str.AppendLine(string.Format("UID:{0}", identifier));
            str.AppendLine(string.Format("DESCRIPTION:{0}", m.Body));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", m.Body));
            str.AppendLine(string.Format("SUMMARY:{0}", m.Subject));
            str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", m.From.Address));
            
            for (int i = 0; i < m.To.Count; i++)
            {
                str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", m.To[i].DisplayName, m.To[i].Address));
            }

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            if (status == "CANCEL")
            {
                str.AppendLine("STATUS:CANCELLED");
            }
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");

            System.Net.Mime.ContentType contype = new System.Net.Mime.ContentType("text/calendar");
            contype.Parameters.Add("method", "REQUEST");
            contype.Parameters.Add("name", "Meeting.ics");
            AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), contype);
            m.AlternateViews.Add(avCal);

            return m;
        }
        private void SendEmail(MailMessage msg)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Port = _ClientPort; 
                client.Host = _ClientHost;
                client.UseDefaultCredentials = true;
                client.EnableSsl = false;                
                client.Send(msg);                
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }
        #endregion

    }
}



