﻿using Recruiting.Application.Base;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetNumBecasByCandidatoIdResponse : ApplicationResponseBase
    {
        public int NumBecas { get; set; }
    }
}
