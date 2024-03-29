﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using MagicEightBallServiceLib;

namespace MagicEightBallServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Console Based WCF Host *****");
            
            using (ServiceHost serviceHost = new ServiceHost(typeof(MagicEightBallService)))
            {
                serviceHost.Open();

                DisplayHostInfo(serviceHost);

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate service.");
                Console.ReadLine();
            }
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Info *****");

            host.Description.Endpoints.ToList().ForEach(se => 
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
            });
            Console.WriteLine(string.Concat(Enumerable.Repeat("*", 20)));
            Console.WriteLine();
        }
    }
}
