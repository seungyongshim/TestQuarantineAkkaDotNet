using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using MessageClassLibrary;
using Microsoft.Extensions.Logging;

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
            ReceiveAsync<StartRemoting>(async s => {
                var remoteActor = await Context.ActorSelection("akka.tcp://RemoteSys@localhost:9000/user/EchoActor")
                    .ResolveOne(TimeSpan.FromSeconds(5));
                remoteActor.Tell(new Msg(500000));
            });
            Receive<Msg>(msg => {
                Console.WriteLine("Received {0} from {1}", msg.Content.Length, Sender);
            });
        }

        protected override void PreStart()
        {
            base.PreStart();

            Context.System.Scheduler.ScheduleTellRepeatedly(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1),
                Self, StartRemoting.Instance, Self);
        }
    }
}
