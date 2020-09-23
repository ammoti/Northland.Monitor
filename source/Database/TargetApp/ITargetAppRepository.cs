using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public interface ITargetAppRepository : IRepository<TargetApp>
    {
        Task<TargetAppModel> GetModelAsync(long id);
        Task<Grid<TargetAppModel>> GridAsync(GridParameters parameters);
        Task<IEnumerable<TargetAppModel>> ListModelAsync();
        Task<IEnumerable<TargetAppModel>> ListModelWithDateAsync(DateTime checkDate);

    }
}
