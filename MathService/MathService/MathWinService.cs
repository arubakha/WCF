using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using MathServiceLibrary;

namespace MathWinServiceHost
{
    public partial class MathWinService : ServiceBase
    {
        private ServiceHost serviceHost;

        public MathWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }

            serviceHost = new ServiceHost(typeof(MathService), new Uri("http://localhost:8081/MathServiceLibrary"));
            //serviceHost = new ServiceHost(typeof(MathService), new Uri("net.pipe://localhost/MathServiceLibrary"));
            //serviceHost = new ServiceHost(typeof(MathService), new Uri("net.tcp://localhost:8081/MathServiceLibrary"));
            serviceHost.AddDefaultEndpoints();

            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
        }
    }
}
