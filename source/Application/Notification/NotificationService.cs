using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public sealed class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationFactory _notificationFactory;
        private readonly INotificationRepository _notificationRepository;

        public NotificationService
        (
            IUnitOfWork unitOfWork,
            INotificationFactory notificationFactory,
            INotificationRepository notificationRepository
        )
        {
            _unitOfWork = unitOfWork;
            _notificationFactory = notificationFactory;
            _notificationRepository = notificationRepository;
        }

        public async Task<IResult<long>> AddAsync(NotificationModel model)
        {
            // var validation = await new AddNotificationModelValidator().ValidationAsync(model);

            // if (validation.Failed)
            // {
            //     return Result<long>.Fail(validation.Message);
            // }       

            var targetApp = _notificationFactory.Create(model);

            await _notificationRepository.AddAsync(targetApp);

            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(targetApp.Id);
        }


        public async Task<IResult> DeleteAsync(long id)
        {

            await _notificationRepository.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public Task<NotificationModel> GetAsync(long id)
        {
            return _notificationRepository.GetModelAsync(id);
        }

        public Task<Grid<NotificationModel>> GridAsync(GridParameters parameters)
        {
            return _notificationRepository.GridAsync(parameters);
        }

        public async Task<IEnumerable<NotificationModel>> ListAsync()
        {
            return await _notificationRepository.ListModelAsync();
        }

        public async Task<IEnumerable<NotificationModel>> ListNotificationWaitedAsync()
        {
            return await _notificationRepository.ListModelWaitedAsync(NotificationState.Waiting);

        }

        public async Task<IResult> UpdateAsync(NotificationModel model)
        {
            // var validation = await new UpdateNotificationModelValidator().ValidationAsync(model);

            // if (validation.Failed)
            // {
            //     return Result.Fail(validation.Message);
            // }

            var targetApp = await _notificationRepository.GetAsync(model.Id);

            if (targetApp is null)
            {
                return Result.Success();
            }
            targetApp.UpdateState((NotificationState)model.State);

            await _notificationRepository.UpdateAsync(targetApp.Id, targetApp);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
