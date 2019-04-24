
using Newtonsoft.Json;
using Recruiting.Application.Graph.Mappers;
using Recruiting.Application.Graph.Messages;
using Recruiting.Application.Graph.Messages.FindMeetingTimesRequest;
using Recruiting.Application.Graph.Messages.FindMeetingTimesResponse;
using Recruiting.Application.Graph.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Application.Graph.Services
{
    public class GraphService : IGraphService
    {
        #region Fields      

        private readonly ICuentaTokenRepository _cuentaTokenRepository;
        private readonly IBlackListSalaRepository _blackListSalasRepository;

        #endregion

        #region Constructors

        public GraphService()
        {
            _cuentaTokenRepository = new CuentaTokenRepository();
            _blackListSalasRepository = new BlackListSalaRepository();
        }

        #endregion

        #region ICentroService

        public async Task<GraphModel> findRoomLists(string accessToken)
        {
            string endpoint = "https://graph.microsoft.com/beta/me/findRoomLists";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string stringResult = await response.Content.ReadAsStringAsync();
                            FindRoomsListResponse findMeetingTimeResponse = JsonConvert.DeserializeObject<FindRoomsListResponse>(stringResult);

                            var retVal = new GraphModel();
                            retVal.Salas = new List<Sala>();

                            foreach (var item in findMeetingTimeResponse.value)
                            {
                                retVal.Salas.Add(new Sala { Name = item.name, Email = item.address });
                            }
                            return retVal;
                        }
                        return null;
                    }
                }
            }
        }

        public SaveTokenResponse SaveToken(string emailCuenta , string token)
        {
            SaveTokenResponse response = new SaveTokenResponse();

            try
            {
                var cuentaToken = _cuentaTokenRepository.GetOne(x => x.Email.Contains(emailCuenta));
                if (cuentaToken != null)
                {
                    cuentaToken.Token = token;
                    cuentaToken.FechaCreacionToken = DateTime.Now;
                    cuentaToken.FechaExpiracionToken = DateTime.Now.AddHours(1);
                    _cuentaTokenRepository.Update(cuentaToken);                  
                    response.IsValid = true;
                }
                
            }
            catch (Exception e)
            {
                response.IsValid = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public GetTokenByIdResponse GetTokenById (int tokenId)
        {
            GetTokenByIdResponse response = new GetTokenByIdResponse();

            try
            {
                var cuentaToken = _cuentaTokenRepository.GetOne(x => x.CuentaTokenId == tokenId);
                response.cuentaToken = cuentaToken.ConvertToCuentaTokenViewModel();
                response.IsValid = true;
            }
            catch (Exception e)
            {
                response.IsValid = false;
                response.ErrorMessage = e.Message;                
            }
            return response;
        }

        public async Task<FindRoomsListResponse> FindRooms(string accessToken, string roomList)
        {
            string endpoint = "https://graph.microsoft.com/beta/me/findRooms";

            if (!string.IsNullOrEmpty(roomList))
            {
                endpoint = endpoint + "(RoomList='" + roomList + "')";
            }

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string stringResult = await response.Content.ReadAsStringAsync();
                            FindRoomsListResponse findRoomsListResponse = JsonConvert.DeserializeObject<FindRoomsListResponse>(stringResult);

                            return findRoomsListResponse;
                        }
                        return null;
                    }
                }
            }
        }


        public async Task<FindMeetingTimeResponse> PostFindMeetingTimes(string accessToken, FindMeetingTimesRequest findMeetingTimesRequest)
        {
            string endpoint = "https://graph.microsoft.com/v1.0/me/findMeetingTimes";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                 
                    findMeetingTimesRequest.meetingDuration = "PT1H";

                    request.Content = new StringContent(JsonConvert.SerializeObject(findMeetingTimesRequest), Encoding.UTF8, "application/json");

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string stringResult = await response.Content.ReadAsStringAsync();
                            FindMeetingTimeResponse findMeetingTimeResponse = JsonConvert.DeserializeObject<FindMeetingTimeResponse>(stringResult);
                            return findMeetingTimeResponse;
                        }
                        return null;
                    }
                }
            }
        }

        public GetStringExcludedRoomsResponse GetStringExcludedRooms(int centroID, int? oficinaId)
        {
            GetStringExcludedRoomsResponse response = new GetStringExcludedRoomsResponse();
            BlackListSala blackListSalas;
            try
            {
                if(oficinaId == null)
                {
                    blackListSalas = _blackListSalasRepository.GetOne(x => x.IsActivo && x.CentroId == centroID && x.OficinaId == null);
                }
                else
                {
                    blackListSalas = _blackListSalasRepository.GetOne(x => x.IsActivo && x.CentroId == centroID && x.OficinaId == oficinaId);
                }
                if(blackListSalas != null)
                {
                    response.StringExcludedRooms = blackListSalas.Salas;
                }               

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        } 

        public GetExcludedRoomsResponse GetExcludedRooms(int CentroId, int? OficinaId, FindRoomsListResponse listaSalas)
        {
            GetExcludedRoomsResponse response = new GetExcludedRoomsResponse();
            response.ExcludedRoomsList = new ExcludedRoomsViewModel();
            response.ExcludedRoomsList.ExcludedRooms = new List<ExcludedRoomViewModel>();
            response.ExcludedRoomsList.CentroId = CentroId;
            response.ExcludedRoomsList.OficinaId = OficinaId;
            BlackListSala blackListSala;
            if (OficinaId == null)
            {
                blackListSala = _blackListSalasRepository.GetOne(x => x.IsActivo && x.CentroId == CentroId && x.OficinaId == null);
            }
            else
            {
                blackListSala = _blackListSalasRepository.GetOne(x => x.IsActivo && x.CentroId == CentroId && x.OficinaId == OficinaId);
            }            
            foreach(var sala in listaSalas.value)
            {
                if(blackListSala == null)
                {
                    ExcludedRoomViewModel excluded = new ExcludedRoomViewModel()
                    {
                        name = sala.name,
                        excluded = false
                    };
                    response.ExcludedRoomsList.ExcludedRooms.Add(excluded);
                }
                else
                {
                    ExcludedRoomViewModel excluded = new ExcludedRoomViewModel()
                    {
                        name = sala.name,
                        excluded = blackListSala.Salas.Contains(sala.name)
                    };
                    response.ExcludedRoomsList.ExcludedRooms.Add(excluded);
                }
              
            }

            return response;
        }


        public SaveExcludedRoomsResponse SaveExcludedRooms(ExcludedRoomsViewModel excludedRoomsViewModel)
        {
            SaveExcludedRoomsResponse response = new SaveExcludedRoomsResponse();
            
            try
            {
                string salasExcluidas = "";
                foreach(var sala in excludedRoomsViewModel.ExcludedRooms)
                {
                    if(sala.excluded)
                    {
                        salasExcluidas = string.Concat(salasExcluidas, sala.name, ";");
                    }
                }
                BlackListSala blacklistSala;
                if(excludedRoomsViewModel.OficinaId == null)
                {
                    blacklistSala = _blackListSalasRepository.GetOne(x => x.IsActivo && x.CentroId == excludedRoomsViewModel.CentroId && x.OficinaId == null);
                }
                else
                {
                    blacklistSala = _blackListSalasRepository.GetOne(x => x.IsActivo && x.CentroId == excludedRoomsViewModel.CentroId && x.OficinaId == excludedRoomsViewModel.OficinaId);
                }
                if(blacklistSala == null)
                {
                    blacklistSala = new BlackListSala()
                    {
                        CentroId = excludedRoomsViewModel.CentroId,
                        OficinaId = excludedRoomsViewModel.OficinaId,
                        IsActivo = true,
                        Salas = salasExcluidas
                    };
                    _blackListSalasRepository.Create(blacklistSala);
                }
                else
                {
                    blacklistSala.Salas = salasExcluidas;
                    _blackListSalasRepository.Update(blacklistSala);
                }

               

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
