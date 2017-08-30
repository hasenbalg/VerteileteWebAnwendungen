using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Model
{
    public class Message
    {
        public int id { get; set; }
        public int fromId { get; set; }
        public int toId { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }

    }
}
