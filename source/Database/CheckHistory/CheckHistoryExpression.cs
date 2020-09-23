using Architecture.Domain;
using Architecture.Model;
using System;
using System.Linq.Expressions;

namespace Architecture.Database
{
    public static class CheckHistoryExpression
    {
        public static Expression<Func<CheckHistory, CheckHistoryModel>> Model => CheckHistory => new CheckHistoryModel
        {
            Id = CheckHistory.Id,
            CheckDate = CheckHistory.CheckDate,
            IsWork = CheckHistory.IsWork,
            MessageCode = CheckHistory.MessageCode,
            
        };

        public static Expression<Func<CheckHistory, bool>> Id(long id)
        {
            return CheckHistory => CheckHistory.Id == id;
        }
    }
}
