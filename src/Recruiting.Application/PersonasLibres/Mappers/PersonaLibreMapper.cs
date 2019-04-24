using Recruiting.Application.Helpers;
using Recruiting.Application.PersonasLibres.Messages;
using Recruiting.Application.PersonasLibres.ViewModels;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Recruiting.Application.PersonasLibres.Mappers
{
    public static class PersonaLibreMapper
    {
        #region Mapper

        public static IEnumerable<PersonaLibreRowViewModel> ConvertToPersonaLibreRowViewModel(this IEnumerable<PersonaLibre> PersonasLibresList)
        {
            var PersonaLibreRowViewModelList = new List<PersonaLibreRowViewModel>();

            if (PersonasLibresList == null) return PersonaLibreRowViewModelList;

            PersonaLibreRowViewModelList = PersonasLibresList.Select(x => x.ConvertToPersonaLibreRowViewModel()).ToList();

            return PersonaLibreRowViewModelList;
        }

        public static IEnumerable<PersonaLibreRowExportToExcelViewModel> ConvertToPersonaLibreRowExportToExcelViewModel(this IEnumerable<PersonaLibre> PersonaLibreList)
        {
            var PersonaLibreRowExportToExcelViewModelList = new List<PersonaLibreRowExportToExcelViewModel>();

            if (PersonaLibreList == null) return PersonaLibreRowExportToExcelViewModelList;

            PersonaLibreRowExportToExcelViewModelList = PersonaLibreList.Select(x => x.ConvertToPersonaLibreRowExportToExcelViewModel()).ToList();

            return PersonaLibreRowExportToExcelViewModelList;           

        }

        public static CreateEditPersonaLibreViewModel ConvertToCreateEditPersonaLibreViewModel(this PersonaLibre PersonaLibre)
        {
            var NivelIdioma = "N/A";
            var NivelIdiomaId = 0;

            foreach (PersonaLibreIdioma idioma in PersonaLibre.LibreIdiomas) {
                if (idioma.IdiomaId == (int)TipoIdiomaEnum.Ingles) {
                    NivelIdioma = idioma.NivelIdioma.Nombre;
                    NivelIdiomaId = idioma.NivelIdiomaId;
                }
            }

            return new CreateEditPersonaLibreViewModel()
            {
                PersonaLibreId = PersonaLibre.PersonaLibreId,
                NroEmpleado = PersonaLibre.NroEmpleado.ToString(),
                Nombre = PersonaLibre.Nombre,
                Apellidos = PersonaLibre.Apellidos,
                Categoria = PersonaLibre.Categoria,
                Linea = PersonaLibre.Linea,
                Celda = PersonaLibre.Celda,
                FechaLiberacion = PersonaLibre.FechaLiberacion,
                NecesidadId = PersonaLibre.NecesidadId,
                Comentario = PersonaLibre.Comentario,
                TipoTecnologiaId = PersonaLibre.TipoTecnologiaId,
                TipoTecnologiaNombre = PersonaLibre.TipoTecnologia?.Nombre,
                IsActivo = PersonaLibre.IsActivo,
                SinNecesidadAsignada = PersonaLibre.SinNecesidadAsignada,
                NivelIdiomaId = NivelIdiomaId,
                NivelIdioma = NivelIdioma,
                Centro = PersonaLibre.Usuario.CentroId != null ? PersonaLibre.Usuario.Centro.Nombre : string.Empty,
                Activo = PersonaLibre.IsActivo
            };
        }



        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "NroEmpleado":
                    attributeName = "NroEmpleado";
                    break;
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                case "Apellidos":
                    attributeName = "Apellidos";
                    break;
                case "Categoria":
                    attributeName = "Categoria";
                    break;
                case "Linea":
                    attributeName = "Linea";
                    break;
                case "Celda":
                    attributeName = "Celda";
                    break;
                case "FechaLiberacion":
                    attributeName = "FechaLiberacion";
                    break;
                case "Necesidad":
                    attributeName = "NecesidadId";
                    break;
                case "Comentario":
                    attributeName = "Comentario";
                    break;
                case "TipoTecnologia":
                    attributeName = "TipoTecnologiaId";
                    break;
                case "IsActivo":
                    attributeName = "IsActivo";
                    break;
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;
            }

            return attributeName;
        }

        public static void UpdatePersonaLibre(this PersonaLibre personaLibre, CreateEditPersonaLibreViewModel viewModel)
        {            
            if (viewModel.PersonaLibreId != null)
            {
                personaLibre.PersonaLibreId = (int)viewModel.PersonaLibreId;
                personaLibre.Modified = ModifiableEntityHelper.GetCurrentDate();
                personaLibre.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            }
            else
            {
                personaLibre.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                personaLibre.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            personaLibre.NroEmpleado = Convert.ToInt32(viewModel.NroEmpleado);
            personaLibre.Nombre = viewModel.Nombre;
            personaLibre.Apellidos = viewModel.Apellidos;
            personaLibre.Categoria = viewModel.Categoria;
            personaLibre.Linea = viewModel.Linea;
            personaLibre.Celda = viewModel.Celda;
            personaLibre.FechaLiberacion = viewModel.FechaLiberacion;
            personaLibre.NecesidadId = viewModel.NecesidadId;
            personaLibre.Comentario = viewModel.Comentario;
            personaLibre.TipoTecnologiaId = viewModel.TipoTecnologiaId;
            personaLibre.SinNecesidadAsignada = viewModel.SinNecesidadAsignada;
            personaLibre.IsActivo = true;
        }

        public static PersonaLibreRowViewModel ConvertToPersonaLibreRowViewModel(this PersonaLibre PersonaLibre)
        {
            var NivelIngles = "N/A";

            if (PersonaLibre.LibreIdiomas.Count > 0) {
                foreach (PersonaLibreIdioma idioma in PersonaLibre.LibreIdiomas)
                {
                    if (idioma.IdiomaId == (int)TipoIdiomaEnum.Ingles)
                    {
                        NivelIngles = idioma.NivelIdioma.Nombre;
                    }
                }
            }
            
            var vieModel = new PersonaLibreRowViewModel()
            {
                PersonaLibreId = PersonaLibre.PersonaLibreId,
                NroEmpleado = PersonaLibre.NroEmpleado,
                Nombre = PersonaLibre.Nombre,
                Apellidos = PersonaLibre.Apellidos,
                Categoria = PersonaLibre.Categoria,
                Linea = PersonaLibre.Linea,
                Celda = PersonaLibre.Celda,
                FechaLiberacion = PersonaLibre.FechaLiberacion,
                NecesidadId = PersonaLibre.NecesidadId,
                Comentario = PersonaLibre.Comentario,
                TipoTecnologiaId = PersonaLibre.TipoTecnologiaId,
                IsActivo = PersonaLibre.IsActivo,
                NivelIdioma = NivelIngles,
                Centro = PersonaLibre.Usuario.CentroId != null ? PersonaLibre.Usuario.Centro.Nombre : string.Empty
            };
            
            return vieModel;
        }


        public static List<PersonaLibre> ConvertToPersonasLibres(PersonasLibresToCreateViewModel personasAGuardar)
        {
            var ListaPersonas = new List<PersonaLibre>();
            foreach (var personaAGuardar in personasAGuardar.PersonaLibreRowViewModelList)
            {
                if (personaAGuardar.isChecked)
                {
                    var persona = new PersonaLibre()
                    {
                        CreatedBy = ModifiableEntityHelper.GetCurrentUser(),
                        Created = ModifiableEntityHelper.GetCurrentDate(),
                        NroEmpleado = personaAGuardar.NroEmpleado,
                        Nombre = personaAGuardar.Nombre,
                        Apellidos = personaAGuardar.Apellidos,
                        Categoria = personaAGuardar.Categoria,
                        Linea = personaAGuardar.Linea,
                        Celda = personaAGuardar.Celda,
                        FechaLiberacion = personaAGuardar.FechaLiberacion,
                        NecesidadId = personaAGuardar.NecesidadId,
                        Comentario = personaAGuardar.Comentario,
                        TipoTecnologiaId = personaAGuardar.TipoTecnologiaId,
                        LibreIdiomas = new Collection<PersonaLibreIdioma>(),
                        IsActivo = true,
                        SinNecesidadAsignada = true
                    };

                    if (personaAGuardar.NivelIdiomaId != null) {
                        persona.LibreIdiomas.Add(new PersonaLibreIdioma {
                            IdiomaId = (int)TipoIdiomaEnum.Ingles,
                            NivelIdiomaId = (int)personaAGuardar.NivelIdiomaId,
                            IsActivo = true
                        });
                    }

                    ListaPersonas.Add(persona);
                }
            }
            return ListaPersonas;        
        }

        public static PersonaLibreRowExportToExcelViewModel ConvertToPersonaLibreRowExportToExcelViewModel(this PersonaLibre PersonaLibre)
        {
            var NivelIngles = "N/A";

            foreach (PersonaLibreIdioma idioma in PersonaLibre.LibreIdiomas) {
                if (idioma.IdiomaId == (int)TipoIdiomaEnum.Ingles) {
                    NivelIngles = idioma.NivelIdioma.Nombre;
                }
            }

            var personaLibreRowExportToExcelViewModel = new PersonaLibreRowExportToExcelViewModel()
            {
                NroEmpleado = PersonaLibre.NroEmpleado,
                Nombre = PersonaLibre.Nombre,
                Apellidos = PersonaLibre.Apellidos,
                Categoria = PersonaLibre.Categoria,
                Linea = PersonaLibre.Linea,
                Celda = PersonaLibre.Celda,
                FechaLiberacion = PersonaLibre.FechaLiberacion.ToShortDateString(),
                NecesidadId = PersonaLibre.NecesidadId,
                Comentario = PersonaLibre.Comentario,
                TipoTecnologiaId = PersonaLibre.TipoTecnologiaId,
                NivelIngles = NivelIngles,
                Centro = PersonaLibre.Usuario.CentroId != null ? PersonaLibre.Usuario.Centro.Nombre : string.Empty
            };
            
            return personaLibreRowExportToExcelViewModel;
        }

        #endregion

    }
}
