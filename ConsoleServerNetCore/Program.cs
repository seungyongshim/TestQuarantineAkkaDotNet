using Akka;
using Akka.Actor;
using Akka.Configuration;
using System;
using System.IO;

namespace ConsoleServerNetCore
{
    class Program
    {
        public static void Main(string[] args)
        {
            var conf = ConfigurationFactory.ParseString(File.ReadAllText("Akka.hocon"));
            var sys = ActorSystem.Create("RemoteSys", conf);

            IActorRef echoActor = sys.ActorOf(Props.Create(() => new EchoActor()),"EchoActor");

            Console.ReadLine();
        }
    }
}
