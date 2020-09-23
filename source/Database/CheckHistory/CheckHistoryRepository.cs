using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public sealed class CheckHistoryRepository : EFRepository<CheckHistory>, ICheckHistoryRepository
    {
        public CheckHistoryRepository(Context context) : base(context) { }

        public Task<CheckHistoryModel> GetModelAsync(long id)
        {
            return Queryable.Where(CheckHistoryExpression.Id(id)).Select(CheckHistoryExpression.Model).SingleOrDefaultAsync();
        }

        public Task<Grid<CheckHistoryModel>> GridAsync(GridParameters parameters)
        {

            return Queryable.Select(CheckHistoryExpression.Model).GridAsync(parameters);
        }

        public async Task<IEnumerable<CheckHistoryModel>> ListModelAsync()
        {
            return await Queryable.Select(CheckHistoryExpression.Model).ToListAsync();
        }
    }
}
