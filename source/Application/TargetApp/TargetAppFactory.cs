using System;
using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public class TargetAppFactory : ITargetAppFactory
    {
        public TargetApp Create(TargetAppModel model)
        {
            return new TargetApp
            (model.Title,
model.Url, model.Interval, DateTime.Now.AddMinutes(model.Interval)
            );
        }
    }
}
