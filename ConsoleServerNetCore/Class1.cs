using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using MessageClassLibrary;

namespace ConsoleServerNetCore
{
    // Runs in a separate process from SendActor
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<Msg>(msg => {
                // echo message back to sender\
                Console.WriteLine("Received {0} from {1}", msg.Content.Length, Sender);
                Sender.Tell(msg);
            });
        }
    }
}
