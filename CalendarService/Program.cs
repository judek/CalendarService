using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace CalendarService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (args[0] == "-console")
            {
                Service1 svc = new Service1();
                svc.StartService(args);
                
                Console.WriteLine("Press Q to quit");
                while (Console.ReadKey().KeyChar != 'Q') ;

                svc.StopService();
            }
            else
            {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
                ServiceBase.Run(ServicesToRun);

            }

        }
    }
}
