using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel; // add refernce -> assembly -> system.servicemodel
using CalculatorLibrary; // add reference -> project -> CalculatorLibrary

namespace Selfhosting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(Calculator));
                host.Open();

                Console.WriteLine("Server started.........");
                Console.WriteLine("Press any key to stop the server");
                Console.ReadLine();

            }
            catch (Exception ex )
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
