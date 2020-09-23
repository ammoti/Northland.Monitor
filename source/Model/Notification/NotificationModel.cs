using System;

namespace Architecture.Model
{
    public class NotificationModel
    {
        public long Id { get; set; }
   
        public string Message { get; set; }

        public string ContactTo { get; set; }
        public int State { get; set; }
        public int Type { get; set; }
    }
}
