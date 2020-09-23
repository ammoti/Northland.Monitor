using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public sealed class CheckHistoryService : ICheckHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICheckHistoryFactory _checkHistoryFactory;
        private readonly ICheckHistoryRepository _checkHistoryRepository;
        private readonly ITargetAppService _targetAppService;

        public CheckHistoryService
        (
            IUnitOfWork unitOfWork,
            ICheckHistoryFactory CheckHistoryFactory,
            ICheckHistoryRepository CheckHistoryRepository,
            ITargetAppService TargetAppService
        )
        {
            _unitOfWork = unitOfWork;
            _checkHistoryFactory = CheckHistoryFactory;
            _checkHistoryRepository = CheckHistoryRepository;
            _targetAppService = TargetAppService;
        }

        public async Task<IResult<long>> AddAsync(CheckHistoryModel model)
        {
            // var validation = await new AddCheckHistoryModelValidator().ValidationAsync(model);

            // if (validation.Failed)
            // {
            //     return Result<long>.Fail(validation.Message);
            // }
 
            var CheckHistory = _checkHistoryFactory.Create(model);

            await _checkHistoryRepository.AddAsync(CheckHistory);

            await _unitOfWork.SaveChangesAsync();

            return Result<long>.Success(CheckHistory.Id);
        }


        public async Task<IResult> DeleteAsync(long id)
        {

            await _checkHistoryRepository.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public Task<CheckHistoryModel> GetAsync(long id)
        {
            return _checkHistoryRepository.GetModelAsync(id);
        }

        public Task<Grid<CheckHistoryModel>> GridAsync(GridParameters parameters)
        {
            return _checkHistoryRepository.GridAsync(parameters);
        }



        public async Task<IEnumerable<CheckHistoryModel>> ListAsync()
        {
            return await _checkHistoryRepository.ListModelAsync();
        }

        public async Task<IResult> UpdateAsync(CheckHistoryModel model)
        {
            // var validation = await new UpdateCheckHistoryModelValidator().ValidationAsync(model);

            // if (validation.Failed)
            // {
            //     return Result.Fail(validation.Message);
            // }

            var CheckHistory = await _checkHistoryRepository.GetAsync(model.Id);

            if (CheckHistory is null)
            {
                return Result.Success();
            }
            await _checkHistoryRepository.UpdateAsync(CheckHistory.Id, CheckHistory);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
