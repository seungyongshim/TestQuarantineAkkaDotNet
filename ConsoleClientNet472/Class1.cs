using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using MessageClassLibrary;

namespace ConsoleClientNet472
{
    

    public class StartRemoting
    {
        public static StartRemoting Instance { get; } = new StartRemoting();
    }

    // Initiates remote contact 
    public class SendActor : ReceiveActor
    {
        public SendActor()
        {
            Receive<StartRemoting>(s => {
                Context.ActorSelection("akka.tcp://RemoteSys@localhost:9000/user/Echo")
                .Tell(new Msg("hi!"));
            });
            Receive<Msg>(msg => {
                Console.WriteLine("Received {0} from {1}", msg.Content, Sender);
            });
        }
    }
}
