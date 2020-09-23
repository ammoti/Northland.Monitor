using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<NotificationModel> GetModelAsync(long id);
        Task<Grid<NotificationModel>> GridAsync(GridParameters parameters);
        Task<IEnumerable<NotificationModel>> ListModelAsync();
        Task<IEnumerable<NotificationModel>> ListModelWaitedAsync(NotificationState state);


    }
}
