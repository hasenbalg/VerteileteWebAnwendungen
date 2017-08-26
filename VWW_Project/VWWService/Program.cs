using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VWWService
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(WCFService))) {
                host.Open();
                Console.WriteLine("Taste druecken um Server zu beenden");
                Console.ReadLine();
            };
        }
    }
}
