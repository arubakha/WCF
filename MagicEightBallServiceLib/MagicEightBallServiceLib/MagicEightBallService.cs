using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

namespace MagicEightBallServiceLib
{
    [ServiceContract]
    interface IEightBall
    {
        [OperationContract]
        string ObtainAnswerToQuestion(string userQuestion);
    }

    public class MagicEightBallService : IEightBall
    {
        public MagicEightBallService()
        {
            Console.Write("The 8-Ball awaits your question...");
        }

        public string ObtainAnswerToQuestion(string userQuestion)
        {
            string[] answers = { "Future Uncertain", "Yes", "No", "Hazy", "Ask again later", "Definitely" };

            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}
