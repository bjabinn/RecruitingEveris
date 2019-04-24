using System;
using System.Collections.Generic;

namespace Recruiting.Application.Graph.ViewModels
{
    public class SendMeetingViewModel
    {
        public int CentroId { get; set; }
        public int? OficinaId { get; set; }
        public int EntrevistadorId { get; set; }
        public string Entrevistador { get; set; }
        public int CandidaturaId { get; set; }
        public bool Presencial { get; set; }
        public string EmailSala { get; set; }
        public DateTime Fecha { get; set; }
        public List<SendMeetingSubEntrevistasViewModel> SendMeetingSubEntrevistas { get; set; }
        public string MensajeSubEntrevistas { get; set; }
    }
}