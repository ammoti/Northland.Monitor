using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public sealed class TargetAppRepository : EFRepository<TargetApp>, ITargetAppRepository
    {
        public TargetAppRepository(Context context) : base(context) { }

        public Task<TargetAppModel> GetModelAsync(long id)
        {
            return Queryable.Where(TargetAppExpression.Id(id)).Select(TargetAppExpression.Model).SingleOrDefaultAsync();
        }

        public Task<Grid<TargetAppModel>> GridAsync(GridParameters parameters)
        {

            return Queryable.Select(TargetAppExpression.Model).GridAsync(parameters);
        }

        public async Task<IEnumerable<TargetAppModel>> ListModelAsync()
        {
            return await Queryable.Select(TargetAppExpression.Model).ToListAsync();
        }

        public async Task<IEnumerable<TargetAppModel>> ListModelWithDateAsync(DateTime checkDate)
        {

            return await Queryable.Where(TargetAppExpression.MonitorList(checkDate)).Select(TargetAppExpression.Model).ToListAsync();
        }
    }
}
