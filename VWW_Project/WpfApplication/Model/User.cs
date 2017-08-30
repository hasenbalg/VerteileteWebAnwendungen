using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Model
{
    public class User
    {
        public  int id { get; set; }
        public  string userName { get; set; }
        public  string firstName { get; set; }
        public  string lastname { get; set; }
        public  bool isOnline { get; set; }
        public  string password { get; set; }

    }
}
