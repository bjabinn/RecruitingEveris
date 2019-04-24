using Recruiting.Application.Centros.Services;
using Recruiting.Application.Graph.Messages;
using Recruiting.Application.Graph.Messages.FindMeetingTimesRequest;
using Recruiting.Application.Graph.Messages.FindMeetingTimesResponse;
using Recruiting.Application.Graph.Services;
using Recruiting.Application.Graph.ViewModels;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Oficinas.Enums;
using Recruiting.Application.Usuarios.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Constantes;
using RecruitingWeb.Properties;
using RecruitingWeb.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{
    public class GraphController : Controller
    {
        private readonly ICentroService _centroService;
        private readonly ICentroRepository _centroRepository;
        private readonly IGraphService _graphService;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;


        public GraphController()
        {
            _centroRepository = new CentroRepository();
            _centroService = new CentroService(_centroRepository);
            _graphService = new GraphService();
            _usuarioRepository = new UsuarioRepository();
            _usuarioService = new UsuarioService(_usuarioRepository);
            _candidaturaRepository = new CandidaturaRepository();         
        }

        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.ModificarCandidatura)]
        public async Task<JsonResult> GetRooms(GetRoomViewModel getRoomViewModel)
        {
            var roomFiltrar = GetRoomFiltrar(getRoomViewModel.CentroId, getRoomViewModel.OficinaId);
            GetRoomResponse response = new GetRoomResponse();
            try
            {
                // Get an access token.                
                string accessToken = GetNewAccessToken(getRoomViewModel.CentroId);

                // Get the room lists defined in a tenant.
                var roomLists = await _graphService.findRoomLists(accessToken);
                GraphModel model = new GraphModel();

                model.Salas = new List<Sala>();

                foreach (var item in roomLists.Salas)
                {                   
                    if (item.Name.Contains(roomFiltrar))
                    {
                        model.Salas.Add(item);
                    }
                }
                var entrevistadorMail = _usuarioService.GetUsuarioById(getRoomViewModel.EntrevistadorId).UsuarioViewModel.Email;
                if (entrevistadorMail == "" || entrevistadorMail == null)
                {
                    response.IsValid = false;
                    response.ErrorMessage = Resources.ErrorGraph_EntrevistadorMail;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                response = await GetSuggestedMeetings(accessToken, model.Salas[0].Email, entrevistadorMail, getRoomViewModel.Fecha, getRoomViewModel.CentroId, getRoomViewModel.OficinaId, getRoomViewModel.IgnorarDisponibilidad);

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                response.IsValid = false;
                response.ErrorMessage = Resources.ErrorGraph_ListaSalas;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }

        private string GetNewAccessToken(int centroId)
        {

            var tokenId = _centroService.GetTokenIdByCentroId(centroId).tokenId;
            var token = _graphService.GetTokenById(tokenId);

            return token.cuentaToken.Token;
        }

        public string GetRoomFiltrar(int Centro, int? Oficina = null)
        {
            switch (Oficina)
            {
                case (int)OficinasEnum.OscarEspla:
                    return "OscarEspla";
                case (int)OficinasEnum.SanJuan:
                    return "PlayaSanJuan";
                case null:
                    switch (Centro)
                    {
                        case (int)CentrosEnum.Alicante:
                            return "OscarEspla";
                        case (int)CentrosEnum.Lisboa:
                            return "CENTERS";
                        case (int)CentrosEnum.Murcia:
                            return "Central";
                        case (int)CentrosEnum.Sevilla:
                            return "Cartuja";
                        case (int)CentrosEnum.Temuco:
                            return "Apoquindo";
                        case (int)CentrosEnum.Tetuan:
                            return "TetouanShore";
                        case (int)CentrosEnum.Trujillo:
                            return "Orbegoso";
                        case (int)CentrosEnum.Tucuman:
                            return "SanMartin";
                        case (int)CentrosEnum.Uberlandia:
                            return "UBT";
                        case (int)CentrosEnum.Salamanca:
                            return "VillaMayor";
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

         

            return "";
        }

        public ActionResult SaveExcludedRooms(ExcludedRoomsViewModel model)
        {
            _graphService.SaveExcludedRooms(model);            
            return RedirectToAction("Volver", "Candidaturas");
        }

        public async Task<ActionResult> ExcludedRooms(int CentroId, int? OficinaId)
        {
            GetExcludedRoomsResponse response = new GetExcludedRoomsResponse();
            try
            {
                string token = GetNewAccessToken(CentroId);
                string nombreFiltrar = GetRoomFiltrar(CentroId, OficinaId);
                var roomLists = await _graphService.findRoomLists(token);
                GraphModel model = new GraphModel();

                model.Salas = new List<Sala>();

                foreach (var item in roomLists.Salas)
                {                    
                    if (item.Name.Contains(nombreFiltrar))
                    {
                        model.Salas.Add(item);
                    }
                }
                var listaSalas = await _graphService.FindRooms(token, model.Salas[0].Email);
                response = _graphService.GetExcludedRooms(CentroId, OficinaId, listaSalas);
                ViewBag.ExcludedRoomsList = response.ExcludedRoomsList;
                response.IsValid = true;                            
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }


            return View(response.ExcludedRoomsList);
        }

        [HttpPost]
        // Get list of the suggestions meetings.
        public async Task<GetRoomResponse> GetSuggestedMeetings(string token, string nombreLista, string entrevistadorMail, DateTime fecha, int centroId, int? oficinaId, bool ignorarDisponibilidad)
        {
            GetRoomResponse response = new GetRoomResponse();
            var fechaInicio = DateTime.Parse(fecha.ToUniversalTime().ToString());
            var fechaFin = fechaInicio;

            try
            {
                string accessToken = token;


                FindMeetingTimesRequest findMeetingTimesRequest = new FindMeetingTimesRequest();
                var attendees = new List<Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.Attendee>();

                List<string> possivelAttendees = new List<string>();

                if(!ignorarDisponibilidad)
                {
                    possivelAttendees.Add(entrevistadorMail);
                }

                foreach (var item in possivelAttendees)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        attendees.Add(new Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.Attendee()
                        {
                            emailAddress = new Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.EmailAddress() { address = item, name = item },
                            type = "required"
                        });
                    }
                }

                findMeetingTimesRequest.timeConstraint = new TimeConstraint()
                {
                    timeslots = new List<Timeslot>() {
                            new Timeslot() {
                            start = new Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.Start() { dateTime = fechaInicio, timeZone = "UTC" },
                            end = new Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.End() { dateTime = fechaFin, timeZone = "UTC" }}}
                };



                // Getting the rooms in the list
                FindRoomsListResponse listaSalas = new FindRoomsListResponse();
                GetStringExcludedRoomsResponse excludedRooms = new GetStringExcludedRoomsResponse();
                if (!string.IsNullOrEmpty(nombreLista))
                {
                    listaSalas = await _graphService.FindRooms(accessToken, nombreLista);
                    excludedRooms = _graphService.GetStringExcludedRooms(centroId, oficinaId);
                }
                if (excludedRooms.IsValid && !string.IsNullOrEmpty(excludedRooms.StringExcludedRooms))
                {
                    listaSalas = FilterListSalas(listaSalas, excludedRooms.StringExcludedRooms);
                }

                for (int i = 0; i < listaSalas.value.Count; i++)
                {
                    if (i < 18 && i < listaSalas.value.Count)
                    {
                        
                        attendees.Add(new Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.Attendee()
                        {
                            emailAddress = new Recruiting.Application.Graph.Messages.FindMeetingTimesRequest.EmailAddress() { address = listaSalas.value[i].address },
                            type = "resource"
                        });
                    }
                    else
                    {
                        break;
                    }
                }


                findMeetingTimesRequest.returnSuggestionReasons = true;
                findMeetingTimesRequest.isOrganizerOptional = true;
                findMeetingTimesRequest.maxCandidates = 100;

                findMeetingTimesRequest.attendees = attendees;


                // Get the the meeting times
                var findMeetingTimes = await _graphService.PostFindMeetingTimes(accessToken, findMeetingTimesRequest);

                if (findMeetingTimes.emptySuggestionsReason.Equals("AttendeesUnavailable"))
                {
                    response.IsValid = false;
                    response.ErrorMessage = Resources.ErrorGraph_Disponibilidad;
                    return response;
                }

                List<FindMeetingTimesRowViewModel> suggestions = FilterSuggestions(findMeetingTimes, listaSalas);

                if (suggestions.Count == 0)
                {
                    response.IsValid = false;
                    response.ErrorMessage = Resources.ErrorGraph_Disponibilidad;
                    return response;
                }

                response.IsValid = true;
                response.salas = new List<SelectListItem>();

                foreach (var sugg in suggestions)
                {
                    foreach (var sala in sugg.Salas)
                    {
                        if(sala.Name != null && sala.Email != null)
                        {
                            SelectListItem listaSala = new SelectListItem();
                            listaSala.Value = sala.Email;
                            listaSala.Text = sala.Name;

                            response.salas.Add(listaSala);
                        }
                    }
                }                
            }
            catch (Exception e)
            {
                response.IsValid = false;
                response.ErrorMessage = e.Message;

            }
            return response;
        }

        private FindRoomsListResponse FilterListSalas(FindRoomsListResponse listasalas, string excludedRooms)
        {
            FindRoomsListResponse salasFiltradas = new FindRoomsListResponse();
            salasFiltradas.value = new List<Value>();

            foreach (var sala in listasalas.value)
            {
                if(!excludedRooms.Contains(sala.name))
                {
                    salasFiltradas.value.Add(sala);
                }
            }

            return salasFiltradas;
        }

        private List<FindMeetingTimesRowViewModel> FilterSuggestions(FindMeetingTimeResponse findMeetingTimes, FindRoomsListResponse listaTodasSalas)
        {
            var retVal = new List<FindMeetingTimesRowViewModel>();

            foreach (var suggestion in findMeetingTimes.meetingTimeSuggestions)
            {
                var rooms = new List<Sala>();
                var attendees = new List<string>();
                int personas = 0;

                foreach (var attendee in suggestion.attendeeAvailability)
                {
                    if (attendee.attendee.emailAddress.address.Substring(0, 4) == "ROOM")
                    {
                        if (attendee.availability == "free")
                        {
                            var sala = listaTodasSalas.value.Find(m => m.address.Equals(attendee.attendee.emailAddress.address));

                            rooms.Add(new Sala() { Email = attendee.attendee.emailAddress.address, Name = sala.name });
                        }
                    }
                    else
                    {
                        personas++;
                        if (attendee.availability == "free")
                        {
                            attendees.Add(attendee.attendee.emailAddress.address);
                        }
                        else
                        {
                            attendees.Clear();
                            break;
                        }
                    }
                    //COMENTAR EL SIGUIENTE IF PARA QUE DEVUELVA MAS SUGERENCIAS DE SALAS
                    //if (rooms.Count > 0 && attendees.Count == personas)
                    //{
                    //    break;
                    //}
                }

                if (rooms.Count > 0 && attendees.Count == personas)
                {
                    StringBuilder strb = new StringBuilder();
                    foreach (var item in attendees)
                    {
                        strb.Append(item);
                        strb.Append('#');
                    }

                    var sugg = new FindMeetingTimesRowViewModel()
                    {
                        Fecha = suggestion.meetingTimeSlot.start.dateTime,
                        Salas = rooms,
                        attendees = strb.ToString()
                    };
                    retVal.Add(sugg);
                }
            }

            return retVal;
        }   
    }
}