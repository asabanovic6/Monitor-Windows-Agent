using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogger
{
    public class eventLogger
    {
        string source;
        static string log = "MWA";
        string command;

        public eventLogger(string command, string source)
        {
            this.source = source;
            this.command = command;
        }

        // ova funkcija bi se trebala izvrsiti samo jednom na računaru
        static public void Registry_Write(RegistryKey rg)
        {
            RegistryKey RegKey = rg;
            //RegistryKey subKey = RegKey.OpenSubKey("SYSTEM",true).OpenSubKey("CurrentControlSet",true).OpenSubKey("Services",true).OpenSubKey("Eventlog",true);
            RegistryKey subKey = RegKey.OpenSubKey("SYSTEM", true).OpenSubKey("CurrentControlSet", true).OpenSubKey("Services", true).OpenSubKey("Eventlog", true);

            //subKey = subKey.CreateSubKey("MWA", true);
            subKey = subKey.CreateSubKey(eventLogger.log, true);

        }

        public void createLog()
        {
            //EventLog.CreateEventSource("Izvor.com", "MWA");
            //EventLog.CreateEventSource(this.source, "MWA");
            EventLog.CreateEventSource(this.source, eventLogger.log);
        }

        public void deleteLog()
        {
            EventLog.Delete(eventLogger.log);
        }

        public void readLog()
        {
            EventLog eventLog = new EventLog();
            //eventLog.Log = "MWA";
            eventLog.Log = eventLogger.log;
            foreach (EventLogEntry log in eventLog.Entries)
            {
                Console.WriteLine("{0}\n", log.Message);
            }
        }

        public string createMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Command:" + Environment.NewLine);
            sb.Append(this.command);
            sb.Append(Environment.NewLine + Environment.NewLine);
            sb.Append("Source:" + Environment.NewLine);
            sb.Append(this.source);
            return sb.ToString();
        }

        public void writeLog()
        {
            //if (!EventLog.SourceExists("Izvor.com"))
            //    EventLog.CreateEventSource("Izvor.com", "MWA");
            if (!EventLog.SourceExists(this.source)) EventLog.CreateEventSource(source, eventLogger.log);
            //EventLog.CreateEventSource(source, "MWA");


            using (EventLog eventLog = new EventLog())
            {
                //eventLog.Source = "Izvor.com";
                eventLog.Source = this.source;
                //eventLog.Log = "MWA";
                eventLog.Log = eventLogger.log;
                //eventLog.Source = "Izvor.com";
                eventLog.Source = this.source;
                //eventLog.WriteEntry("proba2", EventLogEntryType.Information);
                string poruka = createMessage();

                eventLog.WriteEntry(poruka, EventLogEntryType.Information);
            }
            /*if (EventLog.SourceExists("Izvor"))
            {
                EventLog log = new EventLog("ImeAplikacije");
                log.Source = "Izvor";
                log.WriteEntry("poruka", EventLogEntryType.Information);
            }*/
        }
    }
}
