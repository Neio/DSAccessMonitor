using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChange
{
    class DSAccess : IDisposable
    {
        public DSAccess(string remoteComputer, string domain, string username, string password)
        {
            Setup(remoteComputer, domain, username, password);
        }

        public DSAccess(string remoteComputer)
        {
            Setup(remoteComputer, null, null, null);
        }

        public DSAccess()
        {
            Setup(null, null, null, null);
        }

        private void Setup(string remoteComputer, string domain, string username, string password)
        {
            m_watcher = EventLogHelper.GetEventWatcher(remoteComputer, domain, username, password, "Security", s_queryString);
            m_watcher.EventRecordWritten += (sender, e) =>
            {
                if (e.EventRecord != null && NewEvent != null)
                {
                    NewEvent(Parse(e.EventRecord));
                }
            };
            m_watcher.Enabled = true;
        }

        public event Action<DSAccessRecord> NewEvent;

        private EventLogWatcher m_watcher;

        public static IEnumerable<DSAccessRecord> GetRecords(string remoteComputer, string domain, string username, string password)
        {
            return EventLogHelper.GetEvents(remoteComputer, domain, username, password, "Security", s_queryString).Select(item => Parse(item));
        }

        private static DSAccessRecord Parse(EventRecord item)
        {
            var ds = new DSAccessRecord();
            ds.Time = item.TimeCreated.Value;
            ds.Operation = Operation.GetOperation(((string)item.Properties[9].Value).Trim(' ', '%', '\r', '\n', '\t'));
            ds.Target = GetObj(((string)item.Properties[6].Value).Trim(' ', '%', '{', '}'));
            ds.Properties = ((string)item.Properties[11].Value).Split('\n').Select(l => l.Trim(' ', '{', '\t', '}', '\r'))
                .Where(l => !String.IsNullOrWhiteSpace(l) && !l.StartsWith("%%"))
                .Select(l => Property.GetPropertyName(new Guid(l)))
                .Where(n => n != null)
                .ToArray();
            ds.Operator = item.Properties[1].Value as string;
            return ds;
        }

        readonly static string s_queryString = "*[System[EventID=4662]]"; // XPATH Query

        //static MemoryCache s_objCache = new MemoryCache("DSAccessCache");
        static ICache<String> s_objCache = new TimeCache<string>(new TimeSpan(1, 0, 0));
        static String GetObj(string guid)
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

    class DSAccessRecord
    {
        public DateTime Time { get; set; }
        public String Operation { get; set; }
        public String Target { get; set; }
        public String[] Properties { get; set; }
        public String Operator { get; set; }
    }
}
