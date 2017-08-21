using System;

namespace WinClient
{
    public class MyMessage
    {
        public MyUser sender { get; set; }
        public DateTime time { get; set; }
        public string text { get; set; }

        public override string ToString() {
            return sender.email + " " + time.ToString() + " " + text;
        }
    }
}