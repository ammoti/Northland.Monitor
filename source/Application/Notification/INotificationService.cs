using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public interface INotificationService
    {
        Task<IResult<long>> AddAsync(NotificationModel model);

        Task<IResult> DeleteAsync(long id);

        Task<NotificationModel> GetAsync(long id);

        Task<Grid<NotificationModel>> GridAsync(GridParameters parameters);

        Task<IEnumerable<NotificationModel>> ListAsync();
        Task<IEnumerable<NotificationModel>> ListNotificationWaitedAsync();

        Task<IResult> UpdateAsync(NotificationModel model);
    }
}
