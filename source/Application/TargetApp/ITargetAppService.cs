using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public interface ITargetAppService
    {
        Task<IResult<long>> AddAsync(TargetAppModel model);

        Task<IResult> DeleteAsync(long id);

        Task<TargetAppModel> GetAsync(long id);

        Task<Grid<TargetAppModel>> GridAsync(GridParameters parameters);

        Task<IEnumerable<TargetAppModel>> ListAsync();

        Task<IResult> UpdateAsync(TargetAppModel model);
        Task<IResult> CheckStatusCodeAsync(TargetAppModel model);
        Task<IEnumerable<TargetAppModel>> GetMonitorTargets(DateTime datetime);
    }
}
