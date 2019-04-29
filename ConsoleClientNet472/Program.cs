using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;

namespace ConsoleClientNet472
{
    class Program
    {
        public static void Main(string[] args)
        {
            var conf = ConfigurationFactory.ParseString(File.ReadAllText("Akka.hocon"));
            var sys = ActorSystem.Create("ClientSys", conf);

            IActorRef sendActor = sys.ActorOf(Props.Create(() => new SendActor()), "SendActor");

            sendActor.Tell(StartRemoting.Instance);


            Console.ReadLine();
        }
    }
}
