using Recruiting.Application.Maestros.ViewModels;
using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using System;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Services
{
    public class MockNecesidadService : INecesidadService
    {
        #region Constants

        private const int TOTAL_ELEMENTS = 32;

        #endregion

        public GetNecesidadesResponse GetNecesidades(DataTableRequest request)
        {
            var necesidades = new List<NecesidadRowViewModel>();
            var response = new GetNecesidadesResponse()
            {
                IsValid = true,
                NecesidadViewModel = necesidades 
            };

            for (var i = request.PageSize  *request.PageNumber; (i < (request.PageSize * request.PageNumber + request.PageSize)) && (i <= TOTAL_ELEMENTS); i++)
            {

                necesidades.Add(new NecesidadRowViewModel()
                {
                    NecesidadId = (int)i,
                    Cliente = string.Format("Cliente {0}", i),
                    Proyecto = string.Format("Proyecto {0}", i),
                    Tecnologia = string.Format("Tecnologia {0}", i),
                    Perfil = string.Format("Perfil {0}", i),
                    Estado = string.Format("Estado {0}", i),
                    FechaSolicitud = DateTime.Now.AddDays((double)i),
                });
            }

            response.TotalElementos = TOTAL_ELEMENTS;

            return response;
        }

        public GetNecesidadByIdResponse GetNecesidadById(int necesidadId)
        {
            var response = new GetNecesidadByIdResponse()
            {
                IsValid = true,
                NecesidadViewModel = GetMockCreateEditNecesidadViewModel(necesidadId),
            };

            return response;
        }

        public CloneNecesidadResponse CloneNecesidad(int necesidadId)
        {
            var response = new CloneNecesidadResponse()
            {
                IsValid = true,
                CreateEditNecesidadViewModel = GetMockCreateEditNecesidadViewModel(necesidadId),
            };

            return response;
        }

        public DeleteNecesidadResponse DeleteNecesidad(int necesidadId)
        {
            var response = new DeleteNecesidadResponse()
            {
                IsValid = true
            };

            return response;
        }

        public SaveNecesidadResponse SaveNecesidad(CreateEditNecesidadViewModel necesidadViewModel)
        {
            var response = new SaveNecesidadResponse()
            {
                IsValid = true,
                NecesidadId = new Random().Next(0, 1000) 
            };

            return response;
        }

        public GetNecesidadesResponse GetNecesidades()
        {
            throw new NotImplementedException();
        }

        public GetNecesidadesResponse GetNecesidadesCandidatura(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public GetNecesidadesResponse GetNecesidadesByCentroUsuarioId(int CentroUsuarioId)
        {
            throw new NotImplementedException();
        }

        public GetNecesidadesResponse GetNecesidadesPersonasLibres(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public GetNecesidadByCandidaturaIdAndCandidatoIdResponse GetNecesidadByCandidaturaIdAndCandidatoId(int candidaturaId, int candidatoId)
        {
            throw new NotImplementedException();
        }
        public GetNecesidadByNombreCandidatoResponse GetNecesidadByNombreCandidato(string candidato)
        {
            throw new NotImplementedException();
        }

        #region Private Methods

        private CreateEditNecesidadViewModel GetMockCreateEditNecesidadViewModel(int necesidadId)
        {
            return new CreateEditNecesidadViewModel()
            {
                NecesidadId = necesidadId,
                Nombre = string.Format("Nombre {0}", necesidadId),
                OficinaId = necesidadId,
                CentroId = necesidadId,
                SectorId = necesidadId,
                ClienteId = necesidadId,
                ProyectoId = necesidadId,
                TipoServicioId = necesidadId,
                TipoPerfilId = necesidadId,
                TipoTecnologiaId = necesidadId,
                TipoContratacionId = necesidadId,
                TipoPrevisionId = necesidadId,
                MesesAsignacionId = necesidadId,
                DetalleTecnologia = string.Format("DetalleTecnologia {0}", necesidadId),
                DisponibilidadViajes = (new Random().Next(0, 2) != 0),
                DisponibilidadReubicacion = (new Random().Next(0, 2) != 0),
                FechaSolicitud = DateTime.Now,
                FechaCompromiso = DateTime.Now.AddDays(1),
                FechaCierre = DateTime.Now.AddMonths(1),
                EstadoNecesidadId = new Random().Next(0, 5),
            };
        }

        public GetNecesidadesExportToExcellResponse GetNecesidadesExportToExcel(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public SaveNecesidadResponse AbrirNecesidad(int idNecesidad)
        {
            throw new NotImplementedException();
        }

        public SaveNecesidadResponse CerrarNecesidad(int idNecesidad, DateTime FechaIncorporacion)
        {
            throw new NotImplementedException();
        }

        public GetNecesidadesResponse GetNecesidadesPersonasLibres()
        {
            throw new NotImplementedException();
        }

        public bool CheckUltimaNecesidadEnGrupo(int id)
        {
            throw new NotImplementedException();
        }

        public DeleteNecesidadResponse DeleteNecesidad(int necesidadId, bool ultNecesidadGrupo)
        {
            throw new NotImplementedException();
        }

        public GetStaffingNecesidadesResponse GetStaffingNecesidades(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public GetStaffingPersonasResponse GetStaffingPersonas(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public SaveStaffingNecesidadResponse SaveStaffingNecesidad(SaveStaffingNecesidadViewModel staffingNecesidad)
        {
            throw new NotImplementedException();
        }

        public SavePrioridadNecesidadResponse SavePrioridadNecesidad(SavePrioridadNecesidadViewModel staffingNecesidad)
        {
            throw new NotImplementedException();
        }

        public CheckLiberateNecesidadResponse CheckLiberateNecesidad(int necesidadId)
        {
            throw new NotImplementedException();
        }

        public SaveObservacionesStaffingResponse SaveObservacionesStaffing(int necesidadId, string observacionesStaffing)
        {
            throw new NotImplementedException();
        }

        public GetNecesidadesStaffingExportToExcelResponse GetNecesidadesStaffingExportToExcel(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        GetNecesidadesPersonaLibreResponse INecesidadService.GetNecesidadesPersonasLibres()
        {
            throw new NotImplementedException();
        }

        GetNecesidadesCandidaturaResponse INecesidadService.GetNecesidadesCandidatura(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        GetNecesidadesPersonaLibreResponse INecesidadService.GetNecesidadesPersonasLibres(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarTecnologia(int tecnologia, string centro)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarPerfil(int perfil, string centro)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
