using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CandidatoCentroEducativoRowViweModel
    {
        public int CentroId { get; set; }
        public string Centro { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }        
    }
}
