using Recruiting.Business.Repositories;
using Recruiting.Business.WorkflowCandidatura.Messages;
using System;

namespace Recruiting.Business.Services.WorkflowCandidatura
{
    public class WorkflowCandidaturaService : IWorkflowCandidaturaService
    {
        #region Fields

        private IRelacionEtapaRepository _relacionEtapaRepository;
        private IRelacionVistaEtapaRepository _relacionVistaEtapaRepository;

        #endregion

        #region Constructor

        public WorkflowCandidaturaService(IRelacionEtapaRepository relacionEtapaRepository,
            IRelacionVistaEtapaRepository relacionVistaEtapaRepository)
        {
            _relacionEtapaRepository = relacionEtapaRepository;
            _relacionVistaEtapaRepository = relacionVistaEtapaRepository;
        }

        #endregion

        #region IWorkflowCandidatura Methods

        public bool IsExecutable(int etapaOrigenId, int? tipoDecisionId, int estadoOrigenId)
        {
            try
            {
                return _relacionEtapaRepository.Contains(x => 
                    x.EtapaOrigenId == etapaOrigenId && 
                    x.TipoDecisionId == tipoDecisionId && 
                    x.EstadoOrigenId == estadoOrigenId);
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public WorkflowResponseDTO Execute(int etapaOrigenId, int? tipoDecisionId)
        {
            var dto = new WorkflowResponseDTO() { IsValid = true };

            try
            {
                var relacionEtapa = _relacionEtapaRepository.GetOne(x => x.EtapaOrigenId == etapaOrigenId && 
                    x.TipoDecisionId == tipoDecisionId);

                if (relacionEtapa != null)
                {
                    dto.EtapaFinId = relacionEtapa.EtapaFinId;
                    dto.EstadoFinId = relacionEtapa.EstadoFinId;
                }
                else
                {
                    dto.IsValid = false;
                }
            }
            catch (Exception)
            {
                dto.IsValid = false;
            }

            return dto;
        }

        public string GetVista(int etapaId, int estado)
        {
            try
            {
                return _relacionVistaEtapaRepository.GetOne(x => x.EtapaId == etapaId &&
                    x.EstadoId == estado).VistaMostrar;
            }
            catch (Exception)
            {
                return "";
            }

        }

        #endregion
        
    }
}
