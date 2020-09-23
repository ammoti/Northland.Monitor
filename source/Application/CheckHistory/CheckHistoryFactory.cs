using System;
using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public class CheckHistoryFactory : ICheckHistoryFactory
    {
        public CheckHistory Create(CheckHistoryModel model)
        {
            return new CheckHistory
            (
                model.CheckDate, model.IsWork, model.MessageCode
            );
        }
    }
}
