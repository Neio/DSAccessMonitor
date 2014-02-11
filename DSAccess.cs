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
    class DSAccess : DSEvent<DSAccessRecord>
    {
        public DSAccess(string remoteComputer, string domain, string username, string password)
            : base(remoteComputer, domain, username, password) { }

        public DSAccess(string remoteComputer)
            : base(remoteComputer) { }

        public DSAccess() : base() { }

        protected override string GetQueryString()
        {
            return "*[System[EventID=4662]]";
        }

        protected override DSAccessRecord Parse(EventRecord item)
        {
            var ds = new DSAccessRecord();
            ds.Time = item.TimeCreated.Value;
            try
            {
                ds.TargetGuid = new Guid(((string)item.Properties[6].Value).Trim(' ', '%', '{', '}'));
            }
            catch
            {
                ds.TargetGuid = Guid.Empty;
            }

            ds.Operation = Operation.GetOperation(((string)item.Properties[9].Value).Trim(' ', '%', '\r', '\n', '\t'));
            ds.TargetGuid = new Guid(((string)item.Properties[6].Value).Trim(' ', '%', '{', '}'));
            ds.Target = GetDN(((string)item.Properties[6].Value).Trim(' ', '%', '{', '}'));
            ds.Properties = ((string)item.Properties[11].Value).Split('\n').Select(l => l.Trim(' ', '{', '\t', '}', '\r'))
                .Where(l => !String.IsNullOrWhiteSpace(l) && !l.StartsWith("%%"))
                .Select(l => Property.GetPropertyName(new Guid(l)))
                .Where(n => n != null)
                .ToArray();
            ds.Operator = item.Properties[1].Value as string;
            return ds;
        }
    }

    class DSAccessRecord
    {
        public Guid TargetGuid { get; set; }
        public DateTime Time { get; set; }
        public String Operation { get; set; }
        public String Target { get; set; }
        public String[] Properties { get; set; }
        public String Operator { get; set; }
    }
}
