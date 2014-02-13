using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChange
{
    public abstract class DSEvent<T> : IDisposable 
        where T :class
    {
        public DSEvent(string remoteComputer, string domain, string username, string password)
        {
            Setup(remoteComputer, domain, username, password);
        }

        public DSEvent(string remoteComputer)
        {
            Setup(remoteComputer, null, null, null);
        }

        public DSEvent()
        {
            Setup(null, null, null, null);
        }

        private void Setup(string remoteComputer, string domain, string username, string password)
        {
            m_watcher = EventLogHelper.GetEventWatcher(remoteComputer, domain, username, password, "Security", GetQueryString());
            m_watcher.EventRecordWritten += (sender, e) =>
            {
                if (e.EventRecord != null && NewEvent != null)
                {
                    NewEvent(Parse(e.EventRecord));
                }
            };
            m_watcher.Enabled = true;
        }

        public void ResetListener()
        {
            if (!m_watcher.Enabled)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Reset listener");
                Console.ResetColor();
                m_watcher.Enabled = true;
            }
        }

        public event Action<T> NewEvent;

        private EventLogWatcher m_watcher;

        public IEnumerable<T> GetRecords(string remoteComputer, string domain, string username, string password)
        {
            return EventLogHelper.GetEvents(remoteComputer, domain, username, password, "Security", GetQueryString()).Select(item => Parse(item));
        }

        protected virtual T Parse(EventRecord item)
        {
            return default(T);
        }

        protected virtual string GetQueryString()
        {
            return "";
        }

        protected static ICache<String> s_objCache = new TimeCache<string>(new TimeSpan(1, 0, 0));

        protected static String GetDN(string guid)
        {
            return s_objCache.Get(guid, () => {
                try
                {
                    var value = new DirectoryEntry(String.Format("LDAP://<GUID={0}>", guid)).Properties["distinguishedName"].Value as string;
                    return value;
                }
                catch
                {
                    return "<Unknown Object>";
                }
            });
            
        }

        private bool m_disposed = false;

        public void Dispose()
        {
            if (!m_disposed)
            {
                m_disposed = true;
                m_watcher.Enabled = false;
                m_watcher.Dispose();
                m_watcher = null;
            }
        }
    }
}
