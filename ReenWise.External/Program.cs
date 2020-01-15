using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ReenWise.External
{
    static class Program
    {
        /// <summary>
        /// This service gets an access token from Abax and collects data from their API.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new GetToken(),
                new GetApi(), 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
