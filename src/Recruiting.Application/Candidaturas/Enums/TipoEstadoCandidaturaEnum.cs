using System.Collections.Generic;
using System.Linq;
namespace Recruiting.Application.Candidaturas.Enums
{
    public enum TipoEstadoCandidaturaEnum
    {
        FiltradoPeople = 1,
        SegundaEntrevista = 2,
        StandBy = 3,
        CartaOferta = 4,
        Contratado = 5,
        AntiguoCVenBBDD = 6,
        Descartado = 7,
        Entrevista = 8,
        RechazaOferta = 9,
        Renuncia = 10,
        PendienteFiltrado = 11,
        BacklogEntrevista = 12,
        KOOferta = 13,        
        Recontactado = 15,
    }
    public static class ExtensionsTipoEstadoCandidaturaEnum
    {
        public static List<TipoEtapaCandidaturaEnum> GetTiposEstadosCandidaturas(this TipoEstadoCandidaturaEnum[] value)
        {
            var listToReturn = new List<TipoEtapaCandidaturaEnum>();
            foreach (var tipo in value)
            {
                switch (tipo)
                {
                    case TipoEstadoCandidaturaEnum.FiltradoPeople:
                        listToReturn.Add(TipoEtapaCandidaturaEnum.Inicio);
                        listToReturn.Add(TipoEtapaCandidaturaEnum.FiltradoTecnico);
                        break;
                    case TipoEstadoCandidaturaEnum.Recontactado: 
                    case TipoEstadoCandidaturaEnum.StandBy:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarCartaOferta, TipoEtapaCandidaturaEnum.AgendarEntrevistas, TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista
                            ,TipoEtapaCandidaturaEnum.FiltradoTelefonico, TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista, TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta
                        });
                        break;
                    case TipoEstadoCandidaturaEnum.CartaOferta:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarCartaOferta, TipoEtapaCandidaturaEnum.FeedbackCartaOferta, TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta });
                        break;
                    case TipoEstadoCandidaturaEnum.AntiguoCVenBBDD:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarEntrevistas, TipoEtapaCandidaturaEnum.Inicio });
                        break;
                    case TipoEstadoCandidaturaEnum.Descartado:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista, TipoEtapaCandidaturaEnum.FiltradoTecnico, TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista, TipoEtapaCandidaturaEnum.FiltradoTelefonico,
                                                                                     TipoEtapaCandidaturaEnum.FiltradoTelefonico, TipoEtapaCandidaturaEnum.AgendarEntrevistas, TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista, TipoEtapaCandidaturaEnum.AgendarCartaOferta,
                                                                                     TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista, TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta});
                        break;
                    case TipoEstadoCandidaturaEnum.Entrevista:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarEntrevistas, TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista, TipoEtapaCandidaturaEnum.FiltradoTelefonico,
                        TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista, TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista, TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista});
                        break;
                    case TipoEstadoCandidaturaEnum.BacklogEntrevista:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarEntrevistas, TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista });
                        break;
                    case TipoEstadoCandidaturaEnum.Contratado:
                        break;
                    case TipoEstadoCandidaturaEnum.RechazaOferta:
                        break;
                    case TipoEstadoCandidaturaEnum.Renuncia:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarEntrevistas,TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista,
                    TipoEtapaCandidaturaEnum.AgendarCartaOferta,TipoEtapaCandidaturaEnum.FiltradoTecnico,TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta,TipoEtapaCandidaturaEnum.FiltradoTelefonico,
                        TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista, TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista, TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista});
                        break; 
                    default:
                        listToReturn.AddRange(new List<TipoEtapaCandidaturaEnum>() { TipoEtapaCandidaturaEnum.AgendarEntrevistas,TipoEtapaCandidaturaEnum.FeedbackCartaOferta,TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista,
                    TipoEtapaCandidaturaEnum.AgendarCartaOferta,TipoEtapaCandidaturaEnum.FiltradoTecnico,TipoEtapaCandidaturaEnum.Fin,TipoEtapaCandidaturaEnum.Inicio,TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta,TipoEtapaCandidaturaEnum.FiltradoTelefonico,
                        TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista, TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista, TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista});
                        break;
                }
            }

            return listToReturn.Distinct().ToList();
        }
    }
}
