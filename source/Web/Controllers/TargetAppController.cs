using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Application;
using Architecture.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers
{
    [Route("targetApp")]
    [ApiController]
    public class TargetAppController : ControllerBase
    {
        private readonly ITargetAppService _targetAppService;

        public TargetAppController(ITargetAppService targetAppService)
        {
            _targetAppService = targetAppService;
        }

        [HttpPost]
        public Task<IActionResult> AddAsync(TargetAppModel model)
        {
            return _targetAppService.AddAsync(model).ResultAsync();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(long id)
        {
            return _targetAppService.DeleteAsync(id).ResultAsync();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(long id)
        {
            return _targetAppService.GetAsync(id).ResultAsync();
        }

        [HttpGet("grid")]
        public Task<IActionResult> GridAsync([FromQuery] GridParameters parameters)
        {
            return _targetAppService.GridAsync(parameters).ResultAsync();
        }

        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _targetAppService.ListAsync().ResultAsync();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(TargetAppModel model)
        {
            return _targetAppService.UpdateAsync(model).ResultAsync();
        }
    }
}
