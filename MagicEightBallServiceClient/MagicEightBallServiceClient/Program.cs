using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicEightBallServiceClient.ServiceReference;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Ask the Magic 8 Ball *****");

            //using (EightBallClient ball = new EightBallClient("NetTcpBinding_IEightBall"))
            //using (EightBallClient ball = new EightBallClient("BasicHttpBinding_IEightBall"))
            using (EightBallClient ball = new EightBallClient("NetNamedPipeBinding_IEightBall"))
            {
                while (true)
                {
                    Console.WriteLine("Your question (or enter 'q' to quit): ");
                    string question = Console.ReadLine();
                    if (question == "q")
                    {
                        Console.WriteLine("Buy!!!");
                        break;
                    }
                    string answer = ball.ObtainAnswerToQuestion(question);
                    Console.WriteLine("8 Ball says: {0}", answer);
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
