using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Base;

namespace Recruiting.Data.EntityFramework.Repositories
{
    public class UsuarioRepository : RecruitingBaseRepository<Usuario>, IUsuarioRepository
    {
    }
}
