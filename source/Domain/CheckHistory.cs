using DotNetCore.Domain;
using System;

namespace Architecture.Domain
{
    public class CheckHistory : Entity<long>
    {
        public CheckHistory
        (
            DateTime checkDate,
            bool isWork,
            string messageCode

        )
        {
            CheckDate = checkDate;
            IsWork = isWork;
            MessageCode = messageCode;
        }
        public CheckHistory(long id) : base(id) { }

        public DateTime CheckDate { get; private set; }

        public bool IsWork { get; private set; }

        public string MessageCode { get; private set; }
        public TargetApp TargetApp { get; private set; }

    }
}
