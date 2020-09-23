using System;

namespace Architecture.Model
{
    public class CheckHistoryModel
    {
        public long Id { get; set; }
        public DateTime CheckDate { get; set; }
        public bool IsWork { get; set; }
        public string MessageCode { get; set; }
        public TargetAppModel TargetAppModel { get; set; }
    }
}
