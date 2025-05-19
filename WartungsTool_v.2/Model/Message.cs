using System;

namespace WartungsTool_v._2.Model
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
