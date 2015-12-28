using System;
using System.ServiceModel.Web;

namespace G4.WcfService.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost host = new WebServiceHost(typeof(EmployeeService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
