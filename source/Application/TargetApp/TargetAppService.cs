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
    public sealed class TargetAppService : ITargetAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITargetAppFactory _targetAppFactory;
        private readonly ITargetAppRepository _targetAppRepository;

        public TargetAppService
        (
            IUnitOfWork unitOfWork,
            ITargetAppFactory targetAppFactory,
            ITargetAppRepository targetAppRepository
        )
        {
            _unitOfWork = unitOfWork;
            _targetAppFactory = targetAppFactory;
            _targetAppRepository = targetAppRepository;
        }

        public async Task<IResult<long>> AddAsync(TargetAppModel model)
        {
            // var validation = await new AddTargetAppModelValidator().ValidationAsync(model);

            // if (validation.Failed)
            // {
            //     return Result<long>.Fail(validation.Message);
            // }       

            var targetApp = _targetAppFactory.Create(model);

            await _targetAppRepository.AddAsync(targetApp);

            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(targetApp.Id);
        }

        public async Task<IResult> CheckStatusCodeAsync(TargetAppModel model)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(model.Url);
                return Result<int>.Success((int)result.StatusCode);
            }
        }

        public async Task<IResult> DeleteAsync(long id)
        {

            await _targetAppRepository.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public Task<TargetAppModel> GetAsync(long id)
        {
            return _targetAppRepository.GetModelAsync(id);
        }

        public async Task<IEnumerable<TargetAppModel>> GetMonitorTargets(DateTime datetime)
        {
            return await _targetAppRepository.ListModelWithDateAsync(datetime);
        }

        public Task<Grid<TargetAppModel>> GridAsync(GridParameters parameters)
        {
            return _targetAppRepository.GridAsync(parameters);
        }

        public async Task<IEnumerable<TargetAppModel>> ListAsync()
        {
            return await _targetAppRepository.ListModelAsync();
        }

        public async Task<IResult> UpdateAsync(TargetAppModel model)
        {
            // var validation = await new UpdateTargetAppModelValidator().ValidationAsync(model);

            // if (validation.Failed)
            // {
            //     return Result.Fail(validation.Message);
            // }

            var targetApp = await _targetAppRepository.GetAsync(model.Id);

            if (targetApp is null)
            {
                return Result.Success();
            }
            targetApp.UpdateCheck(model.CheckTime.AddMinutes(model.Interval));
            await _targetAppRepository.UpdateAsync(targetApp.Id, targetApp);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
