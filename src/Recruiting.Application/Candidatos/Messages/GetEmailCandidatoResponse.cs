﻿using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetEmailCandidatoResponse : ApplicationResponseBase
    {
        public string EmailCandidato { get; set; }
    }
}
