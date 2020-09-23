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
    public sealed class NotificationRepository : EFRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(Context context) : base(context) { }

        public Task<NotificationModel> GetModelAsync(long id)
        {
            return Queryable.Where(NotificationExpression.Id(id)).Select(NotificationExpression.Model).SingleOrDefaultAsync();
        }

        public Task<Grid<NotificationModel>> GridAsync(GridParameters parameters)
        {

            return Queryable.Select(NotificationExpression.Model).GridAsync(parameters);
        }

        public async Task<IEnumerable<NotificationModel>> ListModelAsync()
        {
            return await Queryable.Select(NotificationExpression.Model).ToListAsync();
        }

        public async Task<IEnumerable<NotificationModel>> ListModelWaitedAsync(NotificationState state)
        {
            return await Queryable.Where(NotificationExpression.Waiting(state)).Select(NotificationExpression.Model).ToListAsync();
        }
    }
}
