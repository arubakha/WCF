using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathClient.ServiceReference;
using System.Threading;
using System.Threading.Tasks;

namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Async Math Client *****");

            using (BasicMathClient mathProxy = new BasicMathClient())
            {
                mathProxy.Open();

                //BeginAdd(mathProxy);

                //AddAsyncEvent(mathProxy);

                AddTPL(mathProxy);

            }

            Console.WriteLine("***** Done *****");

            Console.ReadLine();
        }

        private static void AddTPL(BasicMathClient mathProxy)
        {
            Task<int> task = Task<int>.Factory.FromAsync(mathProxy.BeginAdd, mathProxy.EndAdd, 2, 3, null);

            while (!task.IsCompleted)
            {
                Console.WriteLine("Client working...");
                task.Wait(200);
            }

            task.ContinueWith(a =>
            {
                Console.WriteLine("2 + 3 = {0}", task.Result);
            });
        }

        private static void AddAsyncEvent(BasicMathClient mathProxy)
        {
            bool resultReturned = false;
            mathProxy.AddCompleted += (o, s) =>
            {
                Console.WriteLine("5 + 7 = {0}", s.Result);
                resultReturned = true;
            };

            mathProxy.AddAsync(5, 7);

            while (!resultReturned)
            {
                Thread.Sleep(200);
                Console.WriteLine("Client working...");
            }
        }

        private static void BeginAdd(BasicMathClient mathProxy)
        {
            IAsyncResult result = mathProxy.BeginAdd(2, 3, ar =>
            {
                Console.WriteLine("2 + 3 = {0}", mathProxy.EndAdd(ar));
            }, null);

            while (!result.IsCompleted)
            {
                Thread.Sleep(200);
                Console.WriteLine("Client working...");
            }
        }
    }
}
