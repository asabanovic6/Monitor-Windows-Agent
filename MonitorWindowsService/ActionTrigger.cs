using ImageSender;
using JASONParser;
using PingServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using EventLogger;
using Microsoft.Win32;

namespace MonitorWindowsService
{
    class ActionTrigger
    {
        private readonly Timer _timer;
        private readonly Ping _ping;

        public ActionTrigger()
        {
            Logger.Registry_Write(Registry.LocalMachine);

            int triggerPeriod = (int) new Parser().ConfigParser().keepAlive * 1000;
            _timer = new Timer(triggerPeriod) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
            _ping = new Ping();

            imageSender p1 = new imageSender();
            p1.conn();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _ping.PostJsonAndKeepAliveForService();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
