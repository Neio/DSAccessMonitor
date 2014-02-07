using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChange
{
    class EventLogHelper
    {
        public static EventLogWatcher GetEventWatcher(string remoteComputer, string domain, string username, string password, string path, string queryString)
        {
            try
            {
                return  new EventLogWatcher(GetQuery(remoteComputer, domain, username, password, path, queryString));
            }
            catch (EventLogException e)
            {
                Console.WriteLine("Could not query the remote computer! " + e.Message);
            }
            return null;
        }

        public static IEnumerable<EventRecord> GetEvents(string remoteComputer, string domain, string username, string password, string path, string queryString)
        {
            EventLogQuery query = GetQuery(remoteComputer, domain, username, password, path, queryString);
            query.ReverseDirection = true;
            EventLogReader reader = null;
            try
            {

                reader = new EventLogReader(query);
            }
            catch (EventLogException e)
            {
                Console.WriteLine("Could not query the remote computer! " + e.Message);
            }
            var eventLog = reader.ReadEvent();
            while (eventLog != null)
            {
                yield return eventLog;
                eventLog = reader.ReadEvent();
            }
        }

        private static EventLogQuery GetQuery(string remoteComputer, string domain, string username, string password, string path, string queryString)
        {
            EventLogSession session;

            if (remoteComputer == null)
            {
                session = new EventLogSession();
            }
            else if (domain == null || username == null)
            {
                session = new EventLogSession(remoteComputer);
            }
            else
            {
                using (SecureString pw = new SecureString())
                {
                    password.ToList().ForEach(c => pw.AppendChar(c));
                    session = new EventLogSession(remoteComputer, domain, username, pw, SessionAuthentication.Default);
                }
            }

            // Query the Application log on the remote computer.
            return new EventLogQuery(path, PathType.LogName, queryString) { Session = session };
        }
    }
}
