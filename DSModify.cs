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
    class DSModify : DSEvent<DSModifyRecord>
    {
        public DSModify(string remoteComputer, string domain, string username, string password)
            : base(remoteComputer, domain, username, password) { }

        public DSModify(string remoteComputer)
            : base(remoteComputer) { }

        public DSModify() : base() { }

        protected override string GetQueryString()
        {
            return "*[System[EventID=5136]]";
        }

        protected override DSModifyRecord Parse(EventRecord item)
        {
            var ds = new DSModifyRecord();
            ds.Time = item.TimeCreated.Value;
            ds.Operation = Operation.GetOperation(((string)item.Properties[14].Value).Trim(' ', '%', '\r', '\n', '\t'));
            ds.Target = item.Properties[8].Value as string;
            ds.Property = item.Properties[11].Value as string;
            ds.Value = item.Properties[13].Value as string;
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

    class DSModifyRecord
    {
        public Guid TargetGuid { get; set; }
        public DateTime Time { get; set; }
        public String Operation { get; set; }   // OperationType
        public String Target { get; set; }      // ObjectDN
        public String Property { get; set; }    // AttributeLDAPDisplayName
        public String Value { get; set; }       // AttributeValue
        public String Operator { get; set; }    // SubjectUserName
    }
}
