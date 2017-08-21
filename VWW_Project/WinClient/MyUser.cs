using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
    public class MyUser
    {
        public string email { get; set; }
        public bool isOnline { get; set; }

        public override string ToString()
        {
            return email;
        }
    }
}
