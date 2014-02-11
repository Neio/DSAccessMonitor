﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChange
{
    class Operation
    {
        public static String GetOperation(string type)
        {
            if (s_mapper.ContainsKey(type))
            {
                return s_mapper[type];
            }
            return type;
        }

        static Dictionary<string, string> s_mapper = new Dictionary<string, string>
        {
            {"279", "Undefined Access (no effect) Bit 7"},
            {"1536", "Unused message ID"},
            {"1537", "DELETE"},
            {"1538", "READ_CONTROL"},
            {"1539", "WRITE_DAC"},
            {"1540", "WRITE_OWNER"},
            {"1541", "SYNCHRONIZE"},
            {"1542", "ACCESS_SYS_SEC"},
            {"1543", "MAX_ALLOWED"},
            {"1552", "Unknown specific access (bit 0)"},
            {"1553", "Unknown specific access (bit 1)"},
            {"1554", "Unknown specific access (bit 2)"},
            {"1555", "Unknown specific access (bit 3)"},
            {"1556", "Unknown specific access (bit 4)"},
            {"1557", "Unknown specific access (bit 5)"},
            {"1558", "Unknown specific access (bit 6)"},
            {"1559", "Unknown specific access (bit 7)"},
            {"1560", "Unknown specific access (bit 8)"},
            {"1561", "Unknown specific access (bit 9)"},
            {"1562", "Unknown specific access (bit 10)"},
            {"1563", "Unknown specific access (bit 11)"},
            {"1564", "Unknown specific access (bit 12)"},
            {"1565", "Unknown specific access (bit 13)"},
            {"1566", "Unknown specific access (bit 14)"},
            {"1567", "Unknown specific access (bit 15)"},
            {"1601", "Not used"},
            {"1603", "Assign Primary Token Privilege"},
            {"1604", "Lock Memory Privilege"},
            {"1605", "Increase Memory Quota Privilege"},
            {"1606", "Unsolicited Input Privilege"},
            {"1607", "Trusted Computer Base Privilege"},
            {"1608", "Security Privilege"},
            {"1609", "Take Ownership Privilege"},
            {"1610", "Load/Unload Driver Privilege"},
            {"1611", "Profile System Privilege"},
            {"1612", "Set System Time Privilege"},
            {"1613", "Profile Single Process Privilege"},
            {"1614", "Increment Base Priority Privilege"},
            {"1615", "Create Pagefile Privilege"},
            {"1616", "Create Permanent Object Privilege"},
            {"1617", "Backup Privilege"},
            {"1618", "Restore From Backup Privilege"},
            {"1619", "Shutdown System Privilege"},
            {"1620", "Debug Privilege"},
            {"1621", "View or Change Audit Log Privilege"},
            {"1622", "Change Hardware Environment Privilege"},
            {"1623", "Change Notify (and Traverse) Privilege"},
            {"1624", "Remotely Shut System Down Privilege"},
            {"4352", "Device Access Bit 0"},
            {"4353", "Device Access Bit 1"},
            {"4354", "Device Access Bit 2"},
            {"4355", "Device Access Bit 3"},
            {"4356", "Device Access Bit 4"},
            {"4357", "Device Access Bit 5"},
            {"4358", "Device Access Bit 6"},
            {"4359", "Device Access Bit 7"},
            {"4360", "Device Access Bit 8"},
            {"4361", "Undefined Access (no effect) Bit 9"},
            {"4362", "Undefined Access (no effect) Bit 10"},
            {"4363", "Undefined Access (no effect) Bit 11"},
            {"4364", "Undefined Access (no effect) Bit 12"},
            {"4365", "Undefined Access (no effect) Bit 13"},
            {"4366", "Undefined Access (no effect) Bit 14"},
            {"4367", "Undefined Access (no effect) Bit 15"},
            {"4368", "Query directory"},
            {"4369", "Traverse"},
            {"4370", "Create object in directory"},
            {"4371", "Create sub-directory"},
            {"4372", "Undefined Access (no effect) Bit 4"},
            {"4373", "Undefined Access (no effect) Bit 5"},
            {"4374", "Undefined Access (no effect) Bit 6"},
            {"4375", "Undefined Access (no effect) Bit 7"},
            {"4376", "Undefined Access (no effect) Bit 8"},
            {"4377", "Undefined Access (no effect) Bit 9"},
            {"4378", "Undefined Access (no effect) Bit 10"},
            {"4379", "Undefined Access (no effect) Bit 11"},
            {"4380", "Undefined Access (no effect) Bit 12"},
            {"4381", "Undefined Access (no effect) Bit 13"},
            {"4382", "Undefined Access (no effect) Bit 14"},
            {"4383", "Undefined Access (no effect) Bit 15"},
            {"4384", "Query event state"},
            {"4385", "Modify event state"},
            {"4386", "Undefined Access (no effect) Bit 2"},
            {"4387", "Undefined Access (no effect) Bit 3"},
            {"4388", "Undefined Access (no effect) Bit 4"},
            {"4389", "Undefined Access (no effect) Bit 5"},
            {"4390", "Undefined Access (no effect) Bit 6"},
            {"4391", "Undefined Access (no effect) Bit 7"},
            {"4392", "Undefined Access (no effect) Bit 8"},
            {"4393", "Undefined Access (no effect) Bit 9"},
            {"4394", "Undefined Access (no effect) Bit 10"},
            {"4395", "Undefined Access (no effect) Bit 11"},
            {"4396", "Undefined Access (no effect) Bit 12"},
            {"4397", "Undefined Access (no effect) Bit 13"},
            {"4398", "Undefined Access (no effect) Bit 14"},
            {"4399", "Undefined Access (no effect) Bit 15"},
            {"4416", "ReadData (or ListDirectory)"},
            {"4417", "WriteData (or AddFile)"},
            {"4418", "AppendData (or AddSubdirectory or CreatePipeInstance)"},
            {"4419", "ReadEA"},
            {"4420", "WriteEA"},
            {"4421", "Execute/Traverse"},
            {"4422", "DeleteChild"},
            {"4423", "ReadAttributes"},
            {"4424", "WriteAttributes"},
            {"4425", "Undefined Access (no effect) Bit 9"},
            {"4426", "Undefined Access (no effect) Bit 10"},
            {"4427", "Undefined Access (no effect) Bit 11"},
            {"4428", "Undefined Access (no effect) Bit 12"},
            {"4429", "Undefined Access (no effect) Bit 13"},
            {"4430", "Undefined Access (no effect) Bit 14"},
            {"4431", "Undefined Access (no effect) Bit 15"},
            {"4432", "Query key value"},
            {"4433", "Set key value"},
            {"4434", "Create sub-key"},
            {"4435", "Enumerate sub-keys"},
            {"4436", "Notify about changes to keys"},
            {"4437", "Create Link"},
            {"4438", "Undefined Access (no effect) Bit 6"},
            {"4439", "Undefined Access (no effect) Bit 7"},
            {"4440", "Undefined Access (no effect) Bit 8"},
            {"4441", "Undefined Access (no effect) Bit 9"},
            {"4442", "Undefined Access (no effect) Bit 10"},
            {"4443", "Undefined Access (no effect) Bit 11"},
            {"4444", "Undefined Access (no effect) Bit 12"},
            {"4445", "Undefined Access (no effect) Bit 13"},
            {"4446", "Undefined Access (no effect) Bit 14"},
            {"4447", "Undefined Access (no effect) Bit 15"},
            {"4448", "Query mutant state"},
            {"4449", "Undefined Access (no effect) Bit 1"},
            {"4450", "Undefined Access (no effect) Bit 2"},
            {"4451", "Undefined Access (no effect) Bit 3"},
            {"4452", "Undefined Access (no effect) Bit 4"},
            {"4453", "Undefined Access (no effect) Bit 5"},
            {"4454", "Undefined Access (no effect) Bit 6"},
            {"4455", "Undefined Access (no effect) Bit 7"},
            {"4456", "Undefined Access (no effect) Bit 8"},
            {"4457", "Undefined Access (no effect) Bit 9"},
            {"4458", "Undefined Access (no effect) Bit 10"},
            {"4459", "Undefined Access (no effect) Bit 11"},
            {"4460", "Undefined Access (no effect) Bit 12"},
            {"4461", "Undefined Access (no effect) Bit 13"},
            {"4462", "Undefined Access (no effect) Bit 14"},
            {"4463", "Undefined Access (no effect) Bit 15"},
            {"4464", "Communicate using port"},
            {"4465", "Undefined Access (no effect) Bit 1"},
            {"4466", "Undefined Access (no effect) Bit 2"},
            {"4467", "Undefined Access (no effect) Bit 3"},
            {"4468", "Undefined Access (no effect) Bit 4"},
            {"4469", "Undefined Access (no effect) Bit 5"},
            {"4470", "Undefined Access (no effect) Bit 6"},
            {"4471", "Undefined Access (no effect) Bit 7"},
            {"4472", "Undefined Access (no effect) Bit 8"},
            {"4473", "Undefined Access (no effect) Bit 9"},
            {"4474", "Undefined Access (no effect) Bit 10"},
            {"4475", "Undefined Access (no effect) Bit 11"},
            {"4476", "Undefined Access (no effect) Bit 12"},
            {"4477", "Undefined Access (no effect) Bit 13"},
            {"4478", "Undefined Access (no effect) Bit 14"},
            {"4479", "Undefined Access (no effect) Bit 15"},
            {"4480", "Force process termination"},
            {"4481", "Create new thread in process"},
            {"4482", "Unused access bit"},
            {"4483", "Perform virtual memory operation"},
            {"4484", "Read from process memory"},
            {"4485", "Write to process memory"},
            {"4486", "Duplicate handle into or out of process"},
            {"4487", "Create a subprocess of process"},
            {"4488", "Set process quotas"},
            {"4489", "Set process information"},
            {"4490", "Query process information"},
            {"4491", "Set process termination port"},
            {"4492", "Undefined Access (no effect) Bit 12"},
            {"4493", "Undefined Access (no effect) Bit 13"},
            {"4494", "Undefined Access (no effect) Bit 14"},
            {"4495", "Undefined Access (no effect) Bit 15"},
            {"4496", "Control profile"},
            {"4497", "Undefined Access (no effect) Bit 1"},
            {"4498", "Undefined Access (no effect) Bit 2"},
            {"4499", "Undefined Access (no effect) Bit 3"},
            {"4500", "Undefined Access (no effect) Bit 4"},
            {"4501", "Undefined Access (no effect) Bit 5"},
            {"4502", "Undefined Access (no effect) Bit 6"},
            {"4503", "Undefined Access (no effect) Bit 7"},
            {"4504", "Undefined Access (no effect) Bit 8"},
            {"4505", "Undefined Access (no effect) Bit 9"},
            {"4506", "Undefined Access (no effect) Bit 10"},
            {"4507", "Undefined Access (no effect) Bit 11"},
            {"4508", "Undefined Access (no effect) Bit 12"},
            {"4509", "Undefined Access (no effect) Bit 13"},
            {"4510", "Undefined Access (no effect) Bit 14"},
            {"4511", "Undefined Access (no effect) Bit 15"},
            {"4512", "Query section state"},
            {"4513", "Map section for write"},
            {"4514", "Map section for read"},
            {"4515", "Map section for execute"},
            {"4516", "Extend size"},
            {"4517", "Undefined Access (no effect) Bit 5"},
            {"4518", "Undefined Access (no effect) Bit 6"},
            {"4519", "Undefined Access (no effect) Bit 7"},
            {"4520", "Undefined Access (no effect) Bit 8"},
            {"4521", "Undefined Access (no effect) Bit 9"},
            {"4522", "Undefined Access (no effect) Bit 10"},
            {"4523", "Undefined Access (no effect) Bit 11"},
            {"4524", "Undefined Access (no effect) Bit 12"},
            {"4525", "Undefined Access (no effect) Bit 13"},
            {"4526", "Undefined Access (no effect) Bit 14"},
            {"4527", "Undefined Access (no effect) Bit 15"},
            {"4528", "Query semaphore state"},
            {"4529", "Modify semaphore state"},
            {"4530", "Undefined Access (no effect) Bit 2"},
            {"4531", "Undefined Access (no effect) Bit 3"},
            {"4532", "Undefined Access (no effect) Bit 4"},
            {"4533", "Undefined Access (no effect) Bit 5"},
            {"4534", "Undefined Access (no effect) Bit 6"},
            {"4535", "Undefined Access (no effect) Bit 7"},
            {"4536", "Undefined Access (no effect) Bit 8"},
            {"4537", "Undefined Access (no effect) Bit 9"},
            {"4538", "Undefined Access (no effect) Bit 10"},
            {"4539", "Undefined Access (no effect) Bit 11"},
            {"4540", "Undefined Access (no effect) Bit 12"},
            {"4541", "Undefined Access (no effect) Bit 13"},
            {"4542", "Undefined Access (no effect) Bit 14"},
            {"4543", "Undefined Access (no effect) Bit 15"},
            {"4544", "Use symbolic link"},
            {"4545", "Undefined Access (no effect) Bit 1"},
            {"4546", "Undefined Access (no effect) Bit 2"},
            {"4547", "Undefined Access (no effect) Bit 3"},
            {"4548", "Undefined Access (no effect) Bit 4"},
            {"4549", "Undefined Access (no effect) Bit 5"},
            {"4550", "Undefined Access (no effect) Bit 6"},
            {"4551", "Undefined Access (no effect) Bit 7"},
            {"4552", "Undefined Access (no effect) Bit 8"},
            {"4553", "Undefined Access (no effect) Bit 9"},
            {"4554", "Undefined Access (no effect) Bit 10"},
            {"4555", "Undefined Access (no effect) Bit 11"},
            {"4556", "Undefined Access (no effect) Bit 12"},
            {"4557", "Undefined Access (no effect) Bit 13"},
            {"4558", "Undefined Access (no effect) Bit 14"},
            {"4559", "Undefined Access (no effect) Bit 15"},
            {"4560", "Force thread termination"},
            {"4561", "Suspend or resume thread"},
            {"4562", "Send an alert to thread"},
            {"4563", "Get thread context"},
            {"4564", "Set thread context"},
            {"4565", "Set thread information"},
            {"4566", "Query thread information"},
            {"4567", "Assign a token to the thread"},
            {"4568", "Cause thread to directly impersonate another thread"},
            {"4569", "Directly impersonate this thread"},
            {"4570", "Undefined Access (no effect) Bit 10"},
            {"4571", "Undefined Access (no effect) Bit 11"},
            {"4572", "Undefined Access (no effect) Bit 12"},
            {"4573", "Undefined Access (no effect) Bit 13"},
            {"4574", "Undefined Access (no effect) Bit 14"},
            {"4575", "Undefined Access (no effect) Bit 15"},
            {"4576", "Query timer state"},
            {"4577", "Modify timer state"},
            {"4578", "Undefined Access (no effect) Bit 2"},
            {"4579", "Undefined Access (no effect) Bit 3"},
            {"4580", "Undefined Access (no effect) Bit 4"},
            {"4581", "Undefined Access (no effect) Bit 5"},
            {"4582", "Undefined Access (no effect) Bit 6"},
            {"4584", "Undefined Access (no effect) Bit 8"},
            {"4585", "Undefined Access (no effect) Bit 9"},
            {"4586", "Undefined Access (no effect) Bit 10"},
            {"4587", "Undefined Access (no effect) Bit 11"},
            {"4588", "Undefined Access (no effect) Bit 12"},
            {"4589", "Undefined Access (no effect) Bit 13"},
            {"4590", "Undefined Access (no effect) Bit 14"},
            {"4591", "Undefined Access (no effect) Bit 15"},
            {"4592", "AssignAsPrimary"},
            {"4593", "Duplicate"},
            {"4594", "Impersonate"},
            {"4595", "Query"},
            {"4596", "QuerySource"},
            {"4597", "AdjustPrivileges"},
            {"4598", "AdjustGroups"},
            {"4599", "AdjustDefaultDacl"},
            {"4600", "Undefined Access (no effect) Bit 8"},
            {"4601", "Undefined Access (no effect) Bit 9"},
            {"4602", "Undefined Access (no effect) Bit 10"},
            {"4603", "Undefined Access (no effect) Bit 11"},
            {"4604", "Undefined Access (no effect) Bit 12"},
            {"4605", "Undefined Access (no effect) Bit 13"},
            {"4606", "Undefined Access (no effect) Bit 14"},
            {"4607", "Undefined Access (no effect) Bit 15"},
            {"4608", "Create instance of object type"},
            {"4609", "Undefined Access (no effect) Bit 1"},
            {"4610", "Undefined Access (no effect) Bit 2"},
            {"4611", "Undefined Access (no effect) Bit 3"},
            {"4612", "Undefined Access (no effect) Bit 4"},
            {"4613", "Undefined Access (no effect) Bit 5"},
            {"4614", "Undefined Access (no effect) Bit 6"},
            {"4615", "Undefined Access (no effect) Bit 7"},
            {"4616", "Undefined Access (no effect) Bit 8"},
            {"4617", "Undefined Access (no effect) Bit 9"},
            {"4618", "Undefined Access (no effect) Bit 10"},
            {"4619", "Undefined Access (no effect) Bit 11"},
            {"4620", "Undefined Access (no effect) Bit 12"},
            {"4621", "Undefined Access (no effect) Bit 13"},
            {"4622", "Undefined Access (no effect) Bit 14"},
            {"4623", "Undefined Access (no effect) Bit 15"},
            {"4864", "Query State"},
            {"4865", "Modify State"},
            {"5120", "Channel read message"},
            {"5121", "Channel write message"},
            {"5122", "Channel query information"},
            {"5123", "Channel set information"},
            {"5124", "Undefined Access (no effect) Bit 4"},
            {"5125", "Undefined Access (no effect) Bit 5"},
            {"5126", "Undefined Access (no effect) Bit 6"},
            {"5127", "Undefined Access (no effect) Bit 7"},
            {"5128", "Undefined Access (no effect) Bit 8"},
            {"5129", "Undefined Access (no effect) Bit 9"},
            {"5130", "Undefined Access (no effect) Bit 10"},
            {"5131", "Undefined Access (no effect) Bit 11"},
            {"5132", "Undefined Access (no effect) Bit 12"},
            {"5133", "Undefined Access (no effect) Bit 13"},
            {"5134", "Undefined Access (no effect) Bit 14"},
            {"5135", "Undefined Access (no effect) Bit 15"},
            {"5136", "Assign process"},
            {"5137", "Set Attributes"},
            {"5138", "Query Attributes"},
            {"5139", "Terminate Job"},
            {"5140", "Set Security Attributes"},
            {"5141", "Undefined Access (no effect) Bit 5"},
            {"5142", "Undefined Access (no effect) Bit 6"},
            {"5143", "Undefined Access (no effect) Bit 7"},
            {"5144", "Undefined Access (no effect) Bit 8"},
            {"5145", "Undefined Access (no effect) Bit 9"},
            {"5146", "Undefined Access (no effect) Bit 10"},
            {"5147", "Undefined Access (no effect) Bit 11"},
            {"5148", "Undefined Access (no effect) Bit 12"},
            {"5149", "Undefined Access (no effect) Bit 13"},
            {"5150", "Undefined Access (no effect) Bit 14"},
            {"5151", "Undefined Access (no effect) Bit 15"},
            {"5376", "ConnectToServer"},
            {"5377", "ShutdownServer"},
            {"5378", "InitializeServer"},
            {"5379", "CreateDomain"},
            {"5380", "EnumerateDomains"},
            {"5381", "LookupDomain"},
            {"5382", "Undefined Access (no effect) Bit 6"},
            {"5383", "Undefined Access (no effect) Bit 7"},
            {"5384", "Undefined Access (no effect) Bit 8"},
            {"5385", "Undefined Access (no effect) Bit 9"},
            {"5386", "Undefined Access (no effect) Bit 10"},
            {"5387", "Undefined Access (no effect) Bit 11"},
            {"5388", "Undefined Access (no effect) Bit 12"},
            {"5389", "Undefined Access (no effect) Bit 13"},
            {"5390", "Undefined Access (no effect) Bit 14"},
            {"5391", "Undefined Access (no effect) Bit 15"},
            {"5392", "ReadPasswordParameters"},
            {"5393", "WritePasswordParameters"},
            {"5394", "ReadOtherParameters"},
            {"5395", "WriteOtherParameters"},
            {"5396", "CreateUser"},
            {"5397", "CreateGlobalGroup"},
            {"5398", "CreateLocalGroup"},
            {"5399", "GetLocalGroupMembership"},
            {"5400", "ListAccounts"},
            {"5401", "LookupIDs"},
            {"5402", "AdministerServer"},
            {"5408", "ReadInformation"},
            {"5409", "WriteAccount"},
            {"5410", "AddMember"},
            {"5411", "RemoveMember"},
            {"5412", "ListMembers"},
            {"5424", "AddMember"},
            {"5425", "RemoveMember"},
            {"5426", "ListMembers"},
            {"5427", "ReadInformation"},
            {"5428", "WriteAccount"},
            {"5440", "ReadGeneralInformation"},
            {"5441", "ReadPreferences"},
            {"5442", "WritePreferences"},
            {"5443", "ReadLogon"},
            {"5444", "ReadAccount"},
            {"5445", "WriteAccount"},
            {"5446", "ChangePassword (with knowledge of old password)"},
            {"5447", "SetPassword (without knowledge of old password)"},
            {"5448", "ListGroups"},
            {"5449", "ReadGroupMembership"},
            {"5450", "ChangeGroupMembership"},
            {"5632", "View non-sensitive policy information"},
            {"5633", "View system audit requirements"},
            {"5634", "Get sensitive policy information"},
            {"5635", "Modify domain trust relationships"},
            {"5636", "Create special accounts (for assignment of user rights)"},
            {"5637", "Create a secret object"},
            {"5638", "Create a privilege"},
            {"5639", "Set default quota limits"},
            {"5640", "Change system audit requirements"},
            {"5641", "Administer audit log attributes"},
            {"5642", "Enable/Disable LSA"},
            {"5643", "Lookup Names/SIDs"},
            {"5648", "Change secret value"},
            {"5649", "Query secret value"},
            {"5664", "Query trusted domain name/SID"},
            {"5665", "Retrieve the controllers in the trusted domain"},
            {"5666", "Change the controllers in the trusted domain"},
            {"5667", "Query the Posix ID offset assigned to the trusted domain"},
            {"5668", "Change the Posix ID offset assigned to the trusted domain"},
            {"5680", "Query account information"},
            {"5681", "Change privileges assigned to account"},
            {"5682", "Change quotas assigned to account"},
            {"5683", "Change logon capabilities assigned to account"},
            {"6656", "Enumerate desktops"},
            {"6657", "Read attributes"},
            {"6658", "Access Clipboard"},
            {"6659", "Create desktop"},
            {"6660", "Write attributes"},
            {"6661", "Access global atoms"},
            {"6662", "Exit windows"},
            {"6663", "Unused Access Flag"},
            {"6664", "Include this windowstation in enumerations"},
            {"6665", "Read screen"},
            {"6672", "Read Objects"},
            {"6673", "Create window"},
            {"6674", "Create menu"},
            {"6675", "Hook control"},
            {"6676", "Journal (record)"},
            {"6677", "Journal (playback)"},
            {"6678", "Include this desktop in enumerations"},
            {"6679", "Write objects"},
            {"6680", "Switch to this desktop"},
            {"6912", "Administer print server"},
            {"6913", "Enumerate printers"},
            {"6930", "Full Control"},
            {"6931", "Print"},
            {"6948", "Administer Document"},
            {"7168", "Connect to service controller"},
            {"7169", "Create a new service"},
            {"7170", "Enumerate services"},
            {"7171", "Lock service database for exclusive access"},
            {"7172", "Query service database lock state"},
            {"7173", "Set last-known-good state of service database"},
            {"7184", "Query service configuration information"},
            {"7185", "Set service configuration information"},
            {"7186", "Query status of service"},
            {"7187", "Enumerate dependencies of service"},
            {"7188", "Start the service"},
            {"7189", "Stop the service"},
            {"7190", "Pause or continue the service"},
            {"7191", "Query information from service"},
            {"7192", "Issue service-specific control commands"},
            {"7424", "DDE Share Read"},
            {"7425", "DDE Share Write"},
            {"7426", "DDE Share Initiate Static"},
            {"7427", "DDE Share Initiate Link"},
            {"7428", "DDE Share Request"},
            {"7429", "DDE Share Advise"},
            {"7430", "DDE Share Poke"},
            {"7431", "DDE Share Execute"},
            {"7432", "DDE Share Add Items"},
            {"7433", "DDE Share List Items"},
            {"7680", "Create Child"},
            {"7681", "Delete Child"},
            {"7682", "List Contents"},
            {"7683", "Write Self"},
            {"7684", "Read Property"},
            {"7685", "Write Property"},
            {"7686", "Delete Tree"},
            {"7687", "List Object"},
            {"7688", "Control Access"},

            
            {"14674", "Value Created"},
            {"14675", "Value Deleted"}
        };
    }
}
