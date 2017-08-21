using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
    public class MyEvent
    {
        public  string Location { get; set; }

        public int Id { get; set; }
        public  string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
        public bool IsShared { get; set; }
        public string UserId { get; set; }

        //public virtual User User { get; set; }
    }
}
