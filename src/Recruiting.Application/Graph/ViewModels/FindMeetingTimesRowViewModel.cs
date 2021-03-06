﻿using System;
using System.Collections.Generic;

namespace Recruiting.Application.Graph.ViewModels
{
    public class FindMeetingTimesRowViewModel
    {
        public string attendees { get; set; }
        public List<Sala> Salas { get; set; }
        public DateTime Fecha { get; set; }
        public bool Selected { get; set; }
        public string MailSelected { get; set; }
    }

    public class Sala
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}