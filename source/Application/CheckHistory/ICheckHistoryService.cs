using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public interface ICheckHistoryService
    {
        Task<IResult<long>> AddAsync(CheckHistoryModel model);

        Task<IResult> DeleteAsync(long id);

        Task<CheckHistoryModel> GetAsync(long id);

        Task<Grid<CheckHistoryModel>> GridAsync(GridParameters parameters);

        Task<IEnumerable<CheckHistoryModel>> ListAsync();

        Task<IResult> UpdateAsync(CheckHistoryModel model);
    }
}
