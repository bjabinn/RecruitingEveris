using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.Entities;

namespace Recruiting.Application.Candidaturas.Mappers
{
    public static class CandidaturaSubEntrevistaMapper
    {
        #region Mapper

        public static SubEntrevista ConvertSubEntrevistaViewModelToSubEntrevistaToCreate(SubEntrevistaViewModel subEntrevistaViewModel)
        {
            var subEntrevista = new SubEntrevista();
            subEntrevista.Completada = subEntrevistaViewModel.Completada;
            subEntrevista.EntrevistadorId = subEntrevistaViewModel.EntrevistadorId;
            subEntrevista.EntrevistaId = subEntrevistaViewModel.EntrevistaId.Value;
            subEntrevista.FechaEntrevista = subEntrevistaViewModel.FechaSubEntrevista.Value;
            subEntrevista.TipoSubEntrevistaId = subEntrevistaViewModel.TipoSubEntrevistaId.Value;
            subEntrevista.Presencial = subEntrevistaViewModel.Presencial;
            subEntrevista.CategoriaId = subEntrevistaViewModel.CategoriaId;
            subEntrevista.SalarioDeseado = subEntrevistaViewModel.SalarioDeseado;
            subEntrevista.IncorporacionId = subEntrevistaViewModel.IncorporacionId;
            subEntrevista.DisponibilidadViajes = subEntrevistaViewModel.DisponibilidadViajes;
            subEntrevista.CambioResidencia = subEntrevistaViewModel.CambioResidencia;
            subEntrevista.AvisarAlCandidato = subEntrevistaViewModel.AvisarAlCandidato;
            subEntrevista.IsActivo = true;
            return subEntrevista; // No mapeamos ciertos campos porque este metodo solo se llama al crear una nueva y hay campos que los queremos vacíos siempre.
        }

        public static void UpdateSubEntrevistas(this SubEntrevista subEntrevista, SubEntrevistaViewModel subEntrevistaViewModel)
        {
            subEntrevista.Completada = subEntrevistaViewModel.Completada;
            subEntrevista.FechaEntrevista = subEntrevistaViewModel.FechaSubEntrevista.Value;
            subEntrevista.Observaciones = subEntrevistaViewModel.Observaciones;
            subEntrevista.TipoSubEntrevistaId = subEntrevistaViewModel.TipoSubEntrevistaId;
            subEntrevista.Presencial = subEntrevistaViewModel.Presencial;
            subEntrevista.CategoriaId = subEntrevistaViewModel.CategoriaId;
            subEntrevista.SalarioDeseado = subEntrevistaViewModel.SalarioDeseado;
            subEntrevista.SalarioActual = subEntrevistaViewModel.SalarioActual;
            subEntrevista.SalarioPropuesto = subEntrevistaViewModel.SalarioPropuesto;
            subEntrevista.IncorporacionId = subEntrevistaViewModel.IncorporacionId;
            subEntrevista.DisponibilidadViajes = subEntrevistaViewModel.DisponibilidadViajes;
            subEntrevista.CambioResidencia = subEntrevistaViewModel.CambioResidencia;
            subEntrevista.SuperaSubEntrevista = subEntrevistaViewModel.SuperaSubEntrevista;
            subEntrevista.AvisarAlCandidato = subEntrevistaViewModel.AvisarAlCandidato;
            subEntrevista.IsActivo = subEntrevistaViewModel.Activo;
        }

        public static void UpdateSubentrevistaAlCrear(this SubEntrevista subEntrevista, SubEntrevistaViewModel subEntrevistaViewModel)
        {
            subEntrevista.EntrevistadorId = subEntrevistaViewModel.EntrevistadorId;
            subEntrevista.FechaEntrevista = subEntrevistaViewModel.FechaSubEntrevista.Value;
            subEntrevista.Completada = subEntrevistaViewModel.Completada;
            subEntrevista.TipoSubEntrevistaId = subEntrevistaViewModel.TipoSubEntrevistaId.Value;
            subEntrevista.Presencial = subEntrevistaViewModel.Presencial;
            subEntrevista.AvisarAlCandidato = subEntrevistaViewModel.AvisarAlCandidato;
            subEntrevista.IsActivo = true; // No mapeamos ciertos campos porque no los queremos machacar si hemos hehco una vuelta atrás y un reagendado.
        }

        public static SubEntrevistaViewModel ConvertToSubEntrevistaViewModel(SubEntrevista subEntrevista)
        {
            var subEntrevistaViewModel = new SubEntrevistaViewModel();
            subEntrevistaViewModel.SubEntrevistaId = subEntrevista.SubEntrevistaId;
            subEntrevistaViewModel.Completada = subEntrevista.Completada;
            subEntrevistaViewModel.EntrevistadorId = subEntrevista.EntrevistadorId;
            subEntrevistaViewModel.EntrevistaId = subEntrevista.EntrevistaId;
            subEntrevistaViewModel.FechaSubEntrevista = subEntrevista.FechaEntrevista;
            subEntrevistaViewModel.EntrevistadorName = subEntrevista.Entrevistador.Nombre;
            subEntrevistaViewModel.Observaciones = subEntrevista.Observaciones;
            subEntrevistaViewModel.TipoSubEntrevistaId = subEntrevista.TipoSubEntrevistaId;
            subEntrevistaViewModel.TipoSubEntrevistaNombre = subEntrevista.TipoSubEntrevista?.Nombre;
            subEntrevistaViewModel.SalarioPropuesto = subEntrevista.SalarioPropuesto;
            subEntrevistaViewModel.SalarioDeseado = subEntrevista.SalarioDeseado;
            subEntrevistaViewModel.SalarioActual = subEntrevista.SalarioActual;
            subEntrevistaViewModel.IncorporacionId = subEntrevista.IncorporacionId;
            subEntrevistaViewModel.IncorporacionNombre = subEntrevista.Incorporacion?.Nombre;
            subEntrevistaViewModel.DisponibilidadViajes = subEntrevista.DisponibilidadViajes;
            subEntrevistaViewModel.CambioResidencia = subEntrevista.CambioResidencia;
            subEntrevistaViewModel.CategoriaId = subEntrevista.CategoriaId;
            subEntrevistaViewModel.CategoriaNombre = subEntrevista.Categoria?.Nombre;
            subEntrevistaViewModel.Presencial = subEntrevista.Presencial;
            subEntrevistaViewModel.SuperaSubEntrevista = subEntrevista.SuperaSubEntrevista;
            subEntrevistaViewModel.AvisarAlCandidato = subEntrevista.AvisarAlCandidato;
            subEntrevistaViewModel.Activo = subEntrevista.IsActivo;
            return subEntrevistaViewModel;
        }

        public static SubEntrevista ConvertSubEntrevistaModalViewModelToSubEntrevistaToCreate(SubEntrevistaModalViewModel subEntrevistaModal, Entrevista entrevistaPrincipal)
        {
            var subEntrevista = new SubEntrevista();
            subEntrevista.AvisarAlCandidato = subEntrevistaModal.AvisarAlCAndidatoModal;
            subEntrevista.EntrevistadorId = subEntrevistaModal.EntrevistadorIdModal;
            subEntrevista.TipoSubEntrevistaId = subEntrevistaModal.TipoSubEntrevistaIdModal;
            subEntrevista.FechaEntrevista = subEntrevistaModal.FechaSubEntrevistaModal;
            subEntrevista.Presencial = subEntrevistaModal.PresencialModal;
            subEntrevista.Completada = false;
            subEntrevista.SuperaSubEntrevista = false;
            subEntrevista.EntrevistaId = entrevistaPrincipal.EntrevistaId;
            subEntrevista.SalarioActual = entrevistaPrincipal.Candidatura.SalarioActual;
            subEntrevista.SalarioDeseado = entrevistaPrincipal.Candidatura.SalarioDeseado;
            subEntrevista.SalarioPropuesto = entrevistaPrincipal.Candidatura.SalarioPropuesto;
            subEntrevista.CategoriaId = entrevistaPrincipal.Candidatura.CategoriaId;
            subEntrevista.IncorporacionId = entrevistaPrincipal.Candidatura.IncorporacionId;
            subEntrevista.DisponibilidadViajes = entrevistaPrincipal.Candidatura.DisponibilidadViajes;
            subEntrevista.CambioResidencia = entrevistaPrincipal.Candidatura.CambioResidencia;
            subEntrevista.IsActivo = true;
            return subEntrevista;
        }

        #endregion
    }
}
