using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Model
{
    public class Event
    {
        public  string subject { get; set; }
        public  string desciption { get; set; }
        public  DateTime startDay { get; set; }
        public  bool isFullDay { get; set; }
        public  string startTime { get; set; }

        public  DateTime endDay { get; set; }
        public  string endTime { get; set; }
        public  string location { get; set; }
        public  string color { get; set; }
        public  bool isShared { get; set; }
    }
}
