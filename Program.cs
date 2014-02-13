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
                Console.WriteLine("Active Directory Changes in Remote Event Logs from {0}", args[0]);
                computer = args[0];
            }
            else
            {
                Console.WriteLine("Active Directory Changes in Local Event Logs");
            }
            Console.WriteLine("-- Press Ctrl+C to exit --");

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                s_keepRunning = false;
            };

            TimeSpan eventResetTime = new TimeSpan(1, 0, 0);
            using (DSAccess access = new DSAccess(computer))
            {
                using (DSModify modify = new DSModify(computer))
                {
                    using (DSCreated created = new DSCreated(computer))
                    {
                        access.NewEvent += AccessNewEvent;
                        modify.NewEvent += ObjectModified;
                        created.NewEvent += ObjectCreated;

                        while (s_keepRunning)
                        {
                            DateTime resetTime = DateTime.Now + eventResetTime;

                            while (s_keepRunning && resetTime > DateTime.Now)
                            {
                                Thread.Sleep(100);
                            }

                            created.ResetListener();
                            modify.ResetListener();
                            access.ResetListener();
                        }
                    }
                }
            }
            Console.WriteLine("Stopped");

        }

        static void ObjectCreated(DSCreatedRecord item)
        {
            lock (typeof(Program))
            {
                Console.WriteLine("[Time] {0}", item.Time);
                Console.WriteLine("[Operator] {0}", item.Operator);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[Target] Created: {0}", item.Target);

                Console.ResetColor();

                Console.WriteLine();
            }
        }

        static void ObjectModified(DSModifyRecord item)
        {
            lock (typeof(Program))
            {
                Console.WriteLine("[Time] {0}", item.Time);
                Console.WriteLine("[Operator] {0}", item.Operator);
                Console.WriteLine("[Target] {0}", item.Target);

                if (item.Operation == DSModifyType.ValueCreated)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[{0}] Added: {1}", item.Property, item.Value);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[{0}] Removed: {1}", item.Property, item.Value);
                }

                Console.ResetColor();

                Console.WriteLine();
            }
        }

        static void AccessNewEvent(DSAccessRecord item)
        {
            lock (typeof(Program))
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

    
}
