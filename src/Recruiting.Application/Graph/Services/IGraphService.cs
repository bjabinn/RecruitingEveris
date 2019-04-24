using Recruiting.Application.Graph.Messages;
using Recruiting.Application.Graph.Messages.FindMeetingTimesRequest;
using Recruiting.Application.Graph.Messages.FindMeetingTimesResponse;
using Recruiting.Application.Graph.ViewModels;
using System.Threading.Tasks;

namespace Recruiting.Application.Graph.Services
{
    public interface IGraphService
    {
        #region QueryRequest

        Task<GraphModel> findRoomLists(string accessToken);
        Task<FindRoomsListResponse> FindRooms(string accessToken, string roomList);
        Task<FindMeetingTimeResponse> PostFindMeetingTimes(string accessToken, FindMeetingTimesRequest findMeetingTimesRequest);
        SaveTokenResponse SaveToken(string emailCuenta, string token);
        GetTokenByIdResponse GetTokenById(int tokenId);
        GetStringExcludedRoomsResponse GetStringExcludedRooms(int centroID, int? oficinaId);
        GetExcludedRoomsResponse GetExcludedRooms(int CentroId, int? OficinaId, FindRoomsListResponse listaSalas);
        SaveExcludedRoomsResponse SaveExcludedRooms(ExcludedRoomsViewModel excludedRoomsViewModel);
        #endregion
    }
}
