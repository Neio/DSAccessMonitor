using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChange
{
    class Property
    {
        public static string GetPropertyName(Guid guid)
        {
            lock (typeof(Property))
            {
                if (cache.ContainsKey(guid))
                {
                    return cache[guid];
                }

                var value = Search(guid, "schemaIDGUID", "CN=Schema,CN=Configuration", "lDAPDisplayName")
                    ?? Search(guid, "rightsGuid", "CN=Extended-Rights,CN=Configuration", "displayName")
                    ?? guid.ToString();
                cache.Add(guid, value);
                return value;
            }
        }

        static string Search(Guid guid, string searchProperty, string dn, string propertyToLoad)
        {
            var filter = String.Format("(|({0}={1})({0}={2}))", searchProperty, ParseGuid(guid), guid.ToString());

            try
            {
                using (DirectorySearcher searcher = new DirectorySearcher())
                {
                    searcher.Filter = filter;
                    searcher.PropertiesToLoad.Add(propertyToLoad);
                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.SearchRoot = new DirectoryEntry(String.Format("LDAP://{0},{1}", dn, s_baseDN.Value));
                    var result = searcher.FindOne();
                    if (result != null)
                    {
                        return result.Properties[propertyToLoad].OfType<String>().FirstOrDefault();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }

            return null;
        }

        private static string ParseGuid(Guid guid)
        {
            var escpaedGuid = guid
                   .ToByteArray()
                   .Select(aByte => aByte.ToString("X2"))
                   .Aggregate(new StringBuilder(), (strBuilder, aByte) => strBuilder.AppendFormat("\\{0}", aByte))
                   .ToString();
            return escpaedGuid;
        }

        static Lazy<string> s_baseDN = new Lazy<string>(() =>
            {
                
                using (var rootDomain = Forest.GetCurrentForest().RootDomain.GetDirectoryEntry())
                {
                    return (string)rootDomain.Properties["distinguishedName"].Value;
                }
                
            });

        static Dictionary<Guid, string> cache = new Dictionary<Guid, string> { 
            {new Guid("771727b1-31b8-4cdf-ae62-4fe39fadf89e"), null }, // Pre-set
        };
    }
}
