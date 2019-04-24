using Recruiting.Infra.RepositoryBase;

namespace Recruiting.Data.EntityFramework.Base
{
    public class RecruitingBaseRepository <T> : LinqBaseRepository<T,RecruitingDbContext>
        where T : BaseEntity
    {
    }
}
