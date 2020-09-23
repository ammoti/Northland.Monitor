using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public interface ICheckHistoryRepository : IRepository<CheckHistory>
    {
        Task<CheckHistoryModel> GetModelAsync(long id);
        Task<Grid<CheckHistoryModel>> GridAsync(GridParameters parameters);
        Task<IEnumerable<CheckHistoryModel>> ListModelAsync();

    }
}
