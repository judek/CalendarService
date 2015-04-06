using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace CalendarService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Console.Write("Service starting...");

            Console.WriteLine("started.");
        }


        protected override void OnStop()
        {
            Console.Write("Service stoping...");

            Console.WriteLine("Stopped.");
        }

        public void StartService(string[] args)

        { OnStart(args); }

        public void StopService()

        { OnStop(); }
    }
}
