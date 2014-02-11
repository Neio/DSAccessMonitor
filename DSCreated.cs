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
    class DSCreated : DSEvent<DSCreatedRecord>
    {
        public DSCreated(string remoteComputer, string domain, string username, string password)
            : base(remoteComputer, domain, username, password) { }

        public DSCreated(string remoteComputer)
            : base(remoteComputer) { }

        public DSCreated() : base() { }

        protected override string GetQueryString()
        {
            return "*[System[EventID=5137]]";
        }

        protected override DSCreatedRecord Parse(EventRecord item)
        {
            var ds = new DSCreatedRecord();
            ds.Time = item.TimeCreated.Value;
            ds.Target = item.Properties[8].Value as string;
            ds.Operator = item.Properties[3].Value as string;
            try
            {
                ds.TargetGuid = new Guid(((string)item.Properties[9].Value).Trim(' ', '%', '{', '}'));
            }
            catch
            {
                ds.TargetGuid = Guid.Empty;
            }
            return ds;
        }
    }

    class DSCreatedRecord
    {
        public Guid TargetGuid { get; set; }
        public DateTime Time { get; set; }
        public String Target { get; set; }      // ObjectDN
        public String Operator { get; set; }    // SubjectUserName
    }
}
