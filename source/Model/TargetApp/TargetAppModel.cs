using System;

namespace Architecture.Model
{
    public class TargetAppModel
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }
        public int Interval { get; set; }
        public DateTime CheckTime { get; set; }
    }
}
