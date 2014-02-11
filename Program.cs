using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyChange
{
    class Program
    {
        private static bool s_keepRunning = true;
        static void Main(string[] args)
        {
            string computer = null;
            if (args.Length == 1)
            {
                Console.WriteLine("Listening to Active Directory Access in Remote Event Logs from {0}", args[0]);
                computer = args[0];
            }
            else
            {
                Console.WriteLine("Listening to Active Directory Access in Local Event Logs");
            }
            Console.WriteLine("-- Press Ctrl+C to exit --");

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                s_keepRunning = false;
            };

            using (DSAccess access = new DSAccess(computer))
            {
                using (DSModify modify = new DSModify(computer))
                {
                    access.NewEvent += AccessNewEvent;
                    modify.NewEvent += ModifyNewEvent;

                    while (s_keepRunning)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            Console.WriteLine("Stopped");

        }

        static void ModifyNewEvent(DSModifyRecord item)
        {
            Console.WriteLine("[Time] {0}", item.Time);
            Console.WriteLine("[Operator] {0}", item.Operator);
            Console.WriteLine("[Target] {0}", item.Target);
            Console.WriteLine("[Operation] {0}", item.Operation);
            Console.WriteLine("[Property] {0}", item.Property);
            Console.WriteLine("[Value] {0}", item.Value);

            Console.WriteLine();
        }

        static void AccessNewEvent(DSAccessRecord item)
        {
            Console.WriteLine("[Time] {0}", item.Time);
            Console.WriteLine("[Operator] {0}", item.Operator);
            Console.WriteLine("[Target] {0}", item.Target);
            Console.WriteLine("[Operation] {0}", item.Operation);
            Console.WriteLine("[Properties] {0}", String.Join(",", item.Properties));

            Console.WriteLine();
        }

        

        
    }

    
}
