using DotNetCore.Domain;
using System;

namespace Architecture.Domain
{
    public class TargetApp : Entity<long>
    {
        public TargetApp
        (
            string title,
            string url,
            int interval,
            DateTime checkTime
        )
        {
            Title = title;
            Url = url;
            Interval = interval;
            CheckTime = checkTime;
        }
        public TargetApp(long id) : base(id) { }

        public string Title { get; private set; }

        public string Url { get; private set; }

        public int Interval { get; private set; }
        public DateTime CheckTime { get; private set; }
           public void UpdateCheck(DateTime checkDate)
        {
            CheckTime =checkDate;
        }
    }
}
