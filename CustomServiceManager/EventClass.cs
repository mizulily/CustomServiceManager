using System;
using System.Collections.Generic;
using System.Threading;

using System.ServiceProcess;
using log4net;

namespace CustomServiceManager
{
    class EventClass
    {
        public enum EventModeType { PERIODIC, TRIGGER, UNKNOWN };
        public enum EventProcessType { START, STOP, PAUSE, CONTINUE, RESTART, TOGGLE, UNKNOWN }
        public class TriggerClass
        {
            public enum TriggerStatusType { RUNNING, STOPPED, PAUSED, UNKNOWN }
            private String myTriggerName;
            public ServiceController myController;
            public TriggerStatusType myStatus;

            public TriggerClass(String triggerName, TriggerStatusType st)
            {
                myTriggerName = triggerName;
                myController = new ServiceController(myTriggerName);
                myStatus = st;
            }

            public TriggerClass(String triggerName, String stStr)
            {
                myTriggerName = triggerName;
                myController = new ServiceController(myTriggerName);
                switch (stStr)
                {
                    case "Running": myStatus = TriggerStatusType.RUNNING;   break;
                    case "Paused": myStatus = TriggerStatusType.PAUSED; break;
                    case "Stopped": myStatus = TriggerStatusType.STOPPED;   break;
                    default: myStatus = TriggerStatusType.UNKNOWN;  break;
                }
            }

            public Boolean IsTriggered()
            {
                myController = new ServiceController(myTriggerName);
                if (myStatus == TriggerStatusType.RUNNING && myController.Status == ServiceControllerStatus.Running)
                {
                    return true;
                }
                if (myStatus == TriggerStatusType.STOPPED && myController.Status == ServiceControllerStatus.Stopped)
                {
                    return true;
                }
                if (myStatus == TriggerStatusType.PAUSED && myController.Status == ServiceControllerStatus.Paused)
                {
                    return true;
                }
                return false;
            }

            public String getTriggerStatus()
            {
                if (myStatus == TriggerStatusType.RUNNING)
                    return "running";
                if (myStatus == TriggerStatusType.STOPPED)
                    return "stopped";
                if (myStatus == TriggerStatusType.PAUSED)
                    return "paused";
                return "unknown";
            }
        };


        private readonly ILog Logger = LogManager.GetLogger(typeof(EventClass));

        public Int32 myID;
        public Boolean myEnable = false;
        public EventModeType myEventMode;
        public EventProcessType myEventProcess;

        private Int32 myInterval;
        private Timer myEventClock;

        public ServiceController myServiceController;
        public Boolean IsBinding = false;
        private TriggerClass myTrigger;

        
        public EventClass(String appSettingString)
        {
            String[] StrRaw = appSettingString.Split(',');

            myID = Convert.ToInt16(StrRaw[0]);
            myEnable = Convert.ToBoolean(StrRaw[1]);
            Enum.TryParse(StrRaw[2], out myEventMode);
            Enum.TryParse(StrRaw[3], out myEventProcess);
            myServiceController = new ServiceController(StrRaw[4]);

            if (StrRaw.Length >= 6)
            {
                myInterval = Convert.ToInt32(StrRaw[5]);
                myEventClock = new Timer(new TimerCallback(myElapsedHandler), null, Timeout.Infinite, myInterval);
            }

            if (StrRaw.Length == 7 || StrRaw.Length >=9)
            {
                Logger.Error("invalid parameter number");
            }
            if (StrRaw.Length >= 8) {
                TriggerClass.TriggerStatusType temptp;
                Enum.TryParse(StrRaw[7], out temptp);

                BindTrigger(new TriggerClass(StrRaw[6], temptp));
            }
        }

        public EventClass(Int32 ID, Boolean Enable, EventModeType EventMode, EventProcessType EventProcess,
            ServiceController ServiceController,  Int32 Interval = 1000)
        {
            myID = ID;
            myEnable = Enable;
            myEventMode = EventMode;
            myEventProcess = EventProcess;

            myServiceController = ServiceController;

            myInterval = Interval;
            myEventClock = new Timer(new TimerCallback(myElapsedHandler), null, Timeout.Infinite, myInterval);
        }

        public EventClass(Int32 ID, Boolean Enable, String EventModeStr, String EventProcessStr,
            ServiceController ServiceController, Int32 Interval = 1000)
        {
            myID = ID;
            myEnable = Enable;

            switch (EventModeStr)
            {
                case "Periodic": myEventMode = EventModeType.PERIODIC;  break;
                case "Trigger": myEventMode = EventModeType.TRIGGER;    break;
                default: myEventMode = EventModeType.UNKNOWN;   break;
            }
            
            switch (EventProcessStr)
            {
                case "Start": myEventProcess = EventProcessType.START;  break;
                case "Stop": myEventProcess = EventProcessType.STOP;    break;
                case "Pause":   myEventProcess = EventProcessType.PAUSE;    break;
                case "Continue":    myEventProcess = EventProcessType.CONTINUE; break;
                case "Restart": myEventProcess = EventProcessType.RESTART;  break;
                case "Toggle": myEventProcess = EventProcessType.TOGGLE;    break;
                default: myEventProcess = EventProcessType.UNKNOWN; break;
            }

            myServiceController = ServiceController;

            myInterval = Interval;
            myEventClock = new Timer(new TimerCallback(myElapsedHandler), null, Timeout.Infinite, myInterval);
        }

        public void BindTrigger(TriggerClass tr)
        {
            myTrigger = tr;
            IsBinding = true;
        }

        public String appSettingString()
        {
            List<String> str = new List<String>();
            str.Add(Convert.ToString(myID));
            str.Add(Convert.ToString(myEnable));
            str.Add(Convert.ToString(myEventMode));
            str.Add(Convert.ToString(myEventProcess));
            str.Add(Convert.ToString(myServiceController.ServiceName));
            str.Add(Convert.ToString(myInterval));
            if(myEventMode == EventModeType.TRIGGER)
            {
                str.Add(Convert.ToString(myTrigger.myController.ServiceName));
                str.Add(Convert.ToString(myTrigger.myStatus.ToString()));
            }
            return String.Join(",", str);
        }

        public String dispSettingStr()
        {
            if (myEventMode == EventModeType.PERIODIC)
            {
                Int16 nDay, nHour, nMinute, nSecond;
                Int32 interval = myInterval;
                Int32 interval_int = Convert.ToInt32(interval / 1000.0);

                nDay = Convert.ToInt16(interval_int / 86400.0);
                interval_int -= nDay * 86400;
                nHour = Convert.ToInt16(interval_int / 3600.0);
                interval_int -= nHour * 3600;
                nMinute = Convert.ToInt16(interval_int / 60.0);
                interval_int -= nMinute * 60;
                nSecond = Convert.ToInt16(interval_int);

                String infoStr = "every";
                if(nDay!=0)
                    infoStr = infoStr +  $" {nDay} day";
                if (nHour != 0)
                    infoStr = infoStr + $" {nHour} hr";
                if (nMinute != 0)
                    infoStr = infoStr + $" {nMinute} min";
                if (nSecond != 0)
                    infoStr = infoStr + $" {nSecond} sec";

                return infoStr;
            }
            else if (myEventMode == EventModeType.TRIGGER)
            {
                return $"when {myTrigger.myController.ServiceName} is {myTrigger.getTriggerStatus()}";
            }
            else
                return null;
        }


        public void EnableEvent(Boolean en)
        {
            if (en)
                myEventClock.Change(myInterval, myInterval);
            else
                myEventClock.Change(Timeout.Infinite, myInterval);
        }

        private void myElapsedHandler(object source)
        {
            myServiceController = new ServiceController(myServiceController.ServiceName);
            Logger.Debug($"Ticked, Trigger Service {myTrigger.myController.ServiceName}, Status {myTrigger.myController.Status}");
            Logger.Info($"Ticked, Binding={IsBinding}, Trigger={myTrigger.IsTriggered()}");
            if (myEventMode == EventModeType.PERIODIC || (myEventMode == EventModeType.TRIGGER && IsBinding && myTrigger.IsTriggered()))
            {
                switch (myEventProcess)
                {
                    case EventProcessType.START:
                        Logger.Debug($"Ticked, Target Service {myServiceController.ServiceName}, Status {myServiceController.Status}");
                        if (myServiceController.Status == ServiceControllerStatus.Stopped)
                        {
                            myServiceController.Start();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Running);
                            Logger.Debug($"Event ID[{myID}] - started service '{myServiceController.ServiceName}'");
                        }
                        else
                            Logger.Warn($"Event ID[{myID}] - failed to start service '{myServiceController.ServiceName}'");
                        break;
                    case EventProcessType.STOP:
                        if (myServiceController.CanStop)
                        {
                            myServiceController.Stop();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Stopped);
                            Logger.Debug($"Event ID[{myID}] - stopped service '{myServiceController.ServiceName}'");
                        }
                        else
                            Logger.Warn($"Event ID[{myID}] - failed to stop service '{myServiceController.ServiceName}'");
                        break;
                    case EventProcessType.PAUSE:
                        if (myServiceController.CanPauseAndContinue && myServiceController.Status == ServiceControllerStatus.Running)
                        {
                            myServiceController.Pause();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Paused);
                            Logger.Debug($"Event ID[{myID}] - paused service '{myServiceController.ServiceName}'");
                        }
                        else
                            Logger.Warn($"Event ID[{myID}] - failed to pause service '{myServiceController.ServiceName}'");
                        break;
                    case EventProcessType.CONTINUE:
                        if(myServiceController.CanPauseAndContinue && myServiceController.Status == ServiceControllerStatus.Paused)
                        {
                            myServiceController.Continue();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Running);
                            Logger.Debug($"Event ID[{myID}] - continued service '{myServiceController.ServiceName}'");
                        }
                        else
                            Logger.Warn($"Event ID[{myID}] - failed to continue service '{myServiceController.ServiceName}'");
                        break;
                    case EventProcessType.RESTART:
                        if (myServiceController.CanStop)
                        {
                            myServiceController.Stop();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Stopped);
                            myServiceController.Start();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Running);
                            Logger.Debug($"Event ID[{myID}] - restarted service '{myServiceController.ServiceName}'");
                        }
                        else
                            Logger.Warn($"Event ID[{myID}] - failed to restart service '{myServiceController.ServiceName}'");
                        break;
                    case EventProcessType.TOGGLE:
                        if(myServiceController.Status == ServiceControllerStatus.Running)
                        {
                            myServiceController.Stop();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Stopped);
                            Logger.Debug($"Event ID[{myID}] - stopped service '{myServiceController.ServiceName}'");
                        }
                        else if(myServiceController.Status == ServiceControllerStatus.Stopped)
                        {
                            myServiceController.Start();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Running);
                            Logger.Debug($"Event ID[{myID}] - started service '{myServiceController.ServiceName}'");
                        }
                        else if(myServiceController.Status == ServiceControllerStatus.Paused)
                        {
                            myServiceController.Continue();
                            myServiceController.WaitForStatus(ServiceControllerStatus.Running);
                            Logger.Debug($"Event ID[{myID}] - continued service '{myServiceController.ServiceName}'");
                        }
                        else
                            Logger.Warn($"Event ID[{myID}] - failed to toggle service '{myServiceController.ServiceName}'");
                        break;
                }
            }

            GC.Collect();

        }

    }
}
