using Architecture.Domain;
using Architecture.Model;
using System;
using System.Linq.Expressions;

namespace Architecture.Database
{
    public static class TargetAppExpression
    {
        public static Expression<Func<TargetApp, TargetAppModel>> Model => targetApp => new TargetAppModel
        {
            Id = targetApp.Id,
            Title = targetApp.Title,
            Url = targetApp.Url,
            Interval = targetApp.Interval,
            CheckTime = targetApp.CheckTime
        };

        public static Expression<Func<TargetApp, bool>> Id(long id)
        {
            return targetApp => targetApp.Id == id;
        }
        public static Expression<Func<TargetApp, bool>> MonitorList(DateTime date)
        {
            return targetApp => targetApp.CheckTime <= date;
        }
    }
}
