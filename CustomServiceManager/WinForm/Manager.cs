using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using System.ServiceProcess;
using log4net;

namespace CustomServiceManager
{
    public partial class Manager : Form
    {

        private readonly ILog Logger = LogManager.GetLogger(typeof(Manager));

        private String mySelectedGroupName = Program.SelectedGroup;

        private ServiceController mySelectedServiceController = new ServiceController();
        
        private List<GroupClass> myServiceGroupList;
        private List<EventClass> myEventList;

        private Thread th;

        public Manager()
        {
            
            try
            {
                InitializeComponent();

                if (!LoadServiceList())
                {
                    myServiceGroupList = new List<GroupClass>();
                }
                DisplayServiceList();

                if (!LoadEventList())
                {
                    myEventList = new List<EventClass>();
                }
                lblEventCnt.Text = Convert.ToString(EnableEventCount());

                InitializeEvent();

                sslManagerInfo.Text = $"Manager initialized at {DateTime.Now.ToString("HH:mm:ss")}";
                Logger.Debug("Initialized");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
            }
        }

        #region Service/Event Load
        private Boolean LoadServiceList()
        {
            try
            {
                myServiceGroupList = Setting.LoadGroupList();
                Logger.Debug("Loaded service group list from appSetting");
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
                return false;
            }
        }

        private Boolean LoadEventList()
        {
            try
            {
                myEventList = Setting.LoadEventList();
                Logger.Debug("Loaded event list from appSetting");
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
                return false;
            }
        }
        #endregion

        #region Service Related Methods
        private void ClearServiceInfo()
        {
            lblServInfo.Text = "";
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnRestart.Enabled = false;
        }

        private void DisplayServiceInfo(ServiceController sc)
        {
            lblServInfo.Text = $"{sc.ServiceName}\n\n" +
                               $"Display: {sc.DisplayName}\n" +
                               $"Status: {sc.Status}\n" +
                               $"Type: {sc.ServiceType}\n" +
                               $"Start: {sc.StartType}\n";
            if (sc.Status == ServiceControllerStatus.Running)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnRestart.Enabled = true;
            }
            else if (sc.Status == ServiceControllerStatus.Stopped)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnRestart.Enabled = false;
            }
            else if (sc.Status == ServiceControllerStatus.Paused)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnRestart.Enabled = true;
            }

            if (sc.CanPauseAndContinue)
            {
                btnPause.Enabled = true;
                if (sc.Status == ServiceControllerStatus.Paused)
                    btnPause.Text = "Continue";
                else
                    btnPause.Text = "Pause";
            }
            else
                btnPause.Enabled = false;

            Logger.Info("Updated selected service information");
        }

        private void DisplayServiceList()
        {
            cbbServListConfig.Items.Clear();
            lsbServListConfig.Items.Clear();

            foreach (GroupClass group in myServiceGroupList)
            {
                cbbServListConfig.Items.Add(group.myGroupName);
                if (group.myGroupName == mySelectedGroupName && group.myServiceList.Count > 0)
                {
                    foreach (ServiceController sc in group.myServiceList)
                        lsbServListConfig.Items.Add(sc.ServiceName);
                }
            }
            cbbServListConfig.SelectedItem = mySelectedGroupName;
            ClearServiceInfo();

            Logger.Info("Updated service group list");
        }

        #endregion

        #region Service Operation
        private void StartService()
        {
            mySelectedServiceController.Start();
            mySelectedServiceController.WaitForStatus(ServiceControllerStatus.Running);
        }

        private void StopService()
        {
            mySelectedServiceController.Stop();
            mySelectedServiceController.WaitForStatus(ServiceControllerStatus.Stopped);
        }

        private void RestartService()
        {
            StopService();
            StartService();
        }

        private void PauseService()
        {
            mySelectedServiceController.Pause();
            mySelectedServiceController.WaitForStatus(ServiceControllerStatus.Paused);
        }

        private void ContinueService()
        {
            mySelectedServiceController.Continue();
            mySelectedServiceController.WaitForStatus(ServiceControllerStatus.Running);
        }
        #endregion


        #region Event Related Methods

        private Int32 EnableEventCount()
        {
            Int32 i = 0;
            foreach(EventClass e in myEventList)
            {
                if (e.myEnable == true) i++;
            }
            return i;
        }
        #endregion



        #region Event Handler
        private void btnConfig_Click(object sender, EventArgs e)
        {
            Configure sUI = new Configure();
            sUI.ShowDialog();

            myServiceGroupList = Setting.LoadGroupList();
            mySelectedGroupName = Program.SelectedGroup;
            DisplayServiceList();

            sslManagerInfo.Text = $"Group Info configured at {DateTime.Now.ToString("HH: mm: ss")}";
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            Event tUI = new Event();
            tUI.ShowDialog();

            myEventList = Setting.LoadEventList();
            lblEventCnt.Text = Convert.ToString(EnableEventCount());

            sslManagerInfo.Text = $"Event Info configured at {DateTime.Now.ToString("HH: mm: ss")}";
        }


        private void btnMode_Click(object sender, EventArgs e)
        {
            if(btnMode.Text == "OFF")
            {
                btnMode.Text = "ON";
                btnMode.BackColor = SystemColors.ActiveCaption;

                Logger.Debug($"Auto mode turned ON, {EnableEventCount()} service event(s) enabled");
                sslManagerInfo.Text = $"Auto mode turned ON at {DateTime.Now.ToString("HH:mm:ss")}";

                btnEvent.Enabled = false;

                foreach (EventClass ev in myEventList)
                {
                    if(ev.myEnable)
                        ev.EnableEvent(true);
                }
            }
            else if(btnMode.Text == "ON")
            {
                btnMode.Text = "OFF";
                btnMode.BackColor = SystemColors.ControlDark;

                Logger.Debug($"Auto mode turned OFF, {EnableEventCount()} service event(s) disabled");
                sslManagerInfo.Text = $"Auto mode turned OFF at {DateTime.Now.ToString("HH:mm:ss")}";

                btnEvent.Enabled = true;

                foreach (EventClass ev in myEventList)
                {
                    if (ev.myEnable)
                        ev.EnableEvent(false);
                }
                    
            }

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(StartService));
            try
            {
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' is starting";
                
                th.Start();
                th.Join();
                th.Abort();

                DisplayServiceInfo(mySelectedServiceController);
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' started";
                Logger.Debug($"Service '{mySelectedServiceController.ServiceName}' started");
            }
            catch (Exception err)
            {
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' failed to start";
                Logger.Error("Excpetion: " + err.Message);
                MessageBox.Show(err.Message, "Exception");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(StopService));
            try
            {
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' is stopping";

                th.Start();
                th.Join();
                th.Abort();

                DisplayServiceInfo(mySelectedServiceController);
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' stopped";
                Logger.Debug($"Service '{mySelectedServiceController.ServiceName}' stopped");
            }
            catch (Exception err)
            {
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' failed to stop";
                Logger.Error("Excpetion: " + err.Message);
                MessageBox.Show(err.Message, "Exception");
            }
            
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPause.Text == "Pause")
                {
                    th = new Thread(new ThreadStart(PauseService));

                    sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' is pausing";

                    th.Start();
                    th.Join();
                    th.Abort();

                    DisplayServiceInfo(mySelectedServiceController);
                    sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' paused";
                    Logger.Debug($"Service '{mySelectedServiceController.ServiceName}' paused");
                }
                else if (btnPause.Text == "Continue")
                {
                    th = new Thread(new ThreadStart(ContinueService));

                    sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' is continuing";

                    th.Start();
                    th.Join();
                    th.Abort();

                    ContinueService();
                    DisplayServiceInfo(mySelectedServiceController);
                    sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' continued";
                    Logger.Debug($"Service '{mySelectedServiceController.ServiceName}' continued");
                }
            }
            catch (Exception err)
            {
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' failed to pause or continue";
                Logger.Error("Excpetion: " + err.Message);
                MessageBox.Show(err.Message, "Exception");
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            try
            {
                th = new Thread(new ThreadStart(RestartService));

                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' is restarting";

                th.Start();
                th.Join();
                th.Abort();

                DisplayServiceInfo(mySelectedServiceController);
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' restarted";
                Logger.Debug($"Service '{mySelectedServiceController.ServiceName}' restarted");
            }
            catch (Exception err)
            {
                sslManagerInfo.Text = $"Service '{mySelectedServiceController.ServiceName}' failed to restart";
                Logger.Error("Excpetion: " + err.Message);
                MessageBox.Show(err.Message, "Exception");
            }
        }


        private void cbbServListConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItemString = cbbServListConfig.SelectedItem.ToString();
            mySelectedGroupName = selectedItemString;
            Program.SelectedGroup = mySelectedGroupName;

            lsbServListConfig.Items.Clear();
            foreach (GroupClass group in myServiceGroupList)
            {
                if (group.myGroupName == selectedItemString && group.myServiceList.Count > 0)
                {
                    foreach (ServiceController sc in group.myServiceList)
                    {
                        lsbServListConfig.Items.Add($"{sc.ServiceName}");
                    }

                }
            }
            
            ClearServiceInfo();
        }

        private void lsbServListConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbServListConfig.SelectedIndex >= 0)
            {
                mySelectedServiceController = new ServiceController(lsbServListConfig.SelectedItem.ToString());
                DisplayServiceInfo(mySelectedServiceController);
            }
                
        }

        private void Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Debug("Destroyed");
            GC.Collect();
        }

        private void softwareInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ToolName = $"CustomServiceManager";
            String CorpName = $"SHANGHAI-FANUC Robotics Co., Ltd.";
            String DeptName = $"R&D Software Dept.";
            String AuthorName = $"CJ";
            String CreateDate = $"18-07-31";
            String UpdateDate = $"18-08-10";
            String Version = $"Beta";

            String SoftwareInfo = ToolName + "\n\n" + CorpName + "\n" + DeptName + " / " + AuthorName
                                    + "\n\nCreated:\t" + CreateDate + "\nUpdated:\t" + UpdateDate + "\nVersion:\t" + Version;

            MessageBox.Show(SoftwareInfo, "Software Information");
        }

        #endregion


    }
}
