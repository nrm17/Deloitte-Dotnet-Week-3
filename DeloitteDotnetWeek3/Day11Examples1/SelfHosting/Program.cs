using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using LoginService;

namespace SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Login));
            host.Open();
            Console.WriteLine("Sever started.......");
            Console.WriteLine("Press any key to continue");
        }
    }
}
