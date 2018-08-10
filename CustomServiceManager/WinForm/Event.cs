using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.ServiceProcess;
using log4net;


namespace CustomServiceManager
{
    public partial class Event : Form
    {
        private readonly ILog Logger = LogManager.GetLogger(typeof(Configure));

        private String mySelectedGroupName = Program.SelectedGroup;

        private List<GroupClass> myServiceGroupList;
        private List<EventClass> myEventList;

        private Int32 myMaxID;

        public Event()
        {
            InitializeComponent();

            myInitializeComponent();

            if (!LoadServiceGroupList())
            {
                myServiceGroupList = new List<GroupClass>();
            }
            DisplayServiceGroupList();

            if (!LoadServiceEventList())
            {
                myEventList = new List<EventClass>();
            }
            DisplayServiceEventList();
            myMaxID = findMaxID(myEventList);

            InitializeEvent();

            sslEventInfo.Text = $"Configuration loaded at {DateTime.Now.ToString("HH:mm:ss")}";
            Logger.Debug("Initialized");
        }


        
        #region UI Irrelevant Methods: Load/Save
        private Boolean LoadServiceGroupList()
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

        private Boolean LoadServiceEventList()
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

        private Boolean SaveServiceEventList()
        {
            try { 
                Setting.SaveEventList(myEventList);
                Logger.Debug("Saved service event list to appSetting");
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

        #region UI Irrelevant Methods: Local Operations
        private void ClearServiceEventList()
        {
            myEventList.Clear();
            myMaxID = 0;
            Logger.Info("All events are cleared");
        }

        private void AddServiceEvent(EventClass e)
        {
            //Check Duplication

            myEventList.Add(e);
            myMaxID += 1;
            Logger.Info($"New event added to event list with ID[{e.myID}]");
        }

        private Int32 RemoveServiceEvents(List<Int32> IDList)
        {
            Int32 cnt = 0;

            for(Int32 j = myEventList.Count-1; j >= 0; j--)
            {
                foreach(Int32 i in IDList)
                {
                    if (myEventList[j].myID == i)
                    {
                        myEventList.RemoveAt(j);
                        cnt++;
                        break;
                    }
                }
            }

            Logger.Info($"{cnt} event(s) removed event list");
            return cnt;
        }

        //private Boolean CheckValidation(EventClass ce)
        //{
        //    foreach (EventClass e in myEventList)
        //    {
        //        if (e.myServiceController.ServiceName == ce.myServiceController.ServiceName)
        //        {
        //            Logger.Warn("two events with same service is not recommended");
        //            return false;
        //        }
        //    }
            
        //}

        #endregion

        #region UI Relevant Methods
        private void myInitializeComponent()
        {
            cbbTimeUnit.Items.Add("Seconds");
            cbbTimeUnit.Items.Add("Minutes");
            cbbTimeUnit.Items.Add("Hours");
            cbbTimeUnit.Items.Add("Days");
            //cbbTimeUnit.SelectedItem = "Hours";

            cbbProcess.Items.Add("Start");
            cbbProcess.Items.Add("Stop");
            cbbProcess.Items.Add("Pause");
            cbbProcess.Items.Add("Continue");
            cbbProcess.Items.Add("Restart");
            cbbProcess.Items.Add("Toggle");

            cbbTriggerState.Items.Add("Running");
            cbbTriggerState.Items.Add("Paused");
            cbbTriggerState.Items.Add("Stopped");

        }

        private void DisplayServiceGroupList()
        {
            cbbGroup.Items.Clear();
            cbbTargetService.Items.Clear();            
            cbbTriggerService.Items.Clear();

            foreach (GroupClass group in myServiceGroupList)
            {
                cbbGroup.Items.Add(group.myGroupName);
                if (group.myGroupName == mySelectedGroupName && group.myServiceList.Count > 0)
                {
                    foreach (ServiceController sc in group.myServiceList)
                    {
                        cbbTargetService.Items.Add(sc.ServiceName);
                        cbbTriggerService.Items.Add(sc.ServiceName);
                    }
                }
            }
            cbbGroup.SelectedItem = mySelectedGroupName;
            cbbTriggerService.Items.Add("same as target");
            cbbTriggerService.SelectedIndex = cbbTriggerService.Items.Count-1;
        }


        private void DisplayServiceEventList()
        {
            dgvEventView.Rows.Clear();
            foreach (EventClass e in myEventList)
                dgvEventView.Rows.Add(ParseRow(e));
        }

        private DataGridViewRow ParseRow(EventClass e)
        {
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dgvEventView);
            dr.Cells[0].Value = Convert.ToString(e.myID);
            dr.Cells[1].Value = e.myEnable;

            String modeStr = null;
            switch (e.myEventMode)
            {
                case EventClass.EventModeType.PERIODIC: modeStr = "Periodic"; break;
                case EventClass.EventModeType.TRIGGER: modeStr = "Trigger"; break;
            }

            String procStr = null;
            switch (e.myEventProcess)
            {
                case EventClass.EventProcessType.START: procStr = "Start"; break;
                case EventClass.EventProcessType.STOP: procStr = "Stop"; break;
                case EventClass.EventProcessType.PAUSE: procStr = "Pause"; break;
                case EventClass.EventProcessType.CONTINUE: procStr = "Continue"; break;
                case EventClass.EventProcessType.RESTART: procStr = "Restart"; break;
                case EventClass.EventProcessType.TOGGLE: procStr = "Toggle"; break;
            }

            dr.Cells[2].Value = modeStr;
            dr.Cells[3].Value = procStr;

            dr.Cells[4].Value = e.myServiceController.ServiceName;
            dr.Cells[5].Value = e.dispSettingStr();
            return dr;
        }

        //private EventClass ParseEvent(DataGridViewRow dr)
        //{
        //    Boolean en = Convert.ToBoolean(dr.Cells[1].Value);

        //    EventClass.EventModeType modeType;
        //    String drMode = Convert.ToString(dr.Cells[2].Value);
        //    switch (drMode)
        //    {
        //        case "Periodic": modeType = EventClass.EventModeType.PERIODIC; break;
        //        case "Trigger": modeType = EventClass.EventModeType.TRIGGER; break;
        //        default: modeType = EventClass.EventModeType.PERIODIC; break;
        //    }

        //    EventClass.EventProcessType procType;
        //    String drProc = Convert.ToString(dr.Cells[3].Value);
        //    switch (drProc)
        //    {
        //        case "Start": procType = EventClass.EventProcessType.START; break;
        //        case "Stop": procType = EventClass.EventProcessType.STOP; break;
        //        case "Pause": procType = EventClass.EventProcessType.PAUSE; break;
        //        case "Continue": procType = EventClass.EventProcessType.CONTINUE; break;
        //        case "Restart": procType = EventClass.EventProcessType.RESTART; break;
        //        case "Toggle": procType = EventClass.EventProcessType.TOGGLE; break;
        //        default: procType = EventClass.EventProcessType.TOGGLE; break;
        //    }

        //    return new EventClass(Convert.ToInt16(dgvEventView.Rows.Count + 1), en, modeType, procType,
        //                            Convert.ToString(dr.Cells[4].Value),)
        //}

        private Int32 findMaxID(List<EventClass> el)
        {
            Int32 max = 0;
            foreach(EventClass e in el)
                if (e.myID > max) max = e.myID;
            return max;
        }

        #endregion


        #region Event Handlers
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearServiceEventList();
            DisplayServiceEventList();
            sslEventInfo.Text = $"All events are cleared";
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            if (LoadServiceEventList())
            {
                DisplayServiceEventList();
                myMaxID = findMaxID(myEventList);
                sslEventInfo.Text = $"Configured Event List reloaded from appSetting at {DateTime.Now.ToString("HH:mm:ss")}";
            }
            else
                sslEventInfo.Text = $"Configured Event List reloaded from appSetting failed";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveServiceEventList();
            sslEventInfo.Text = $"Configured Event List saved to appSetting at {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbbTargetService.SelectedIndex<0 || cbbProcess.SelectedIndex < 0 
                    || (rdbPeriodic.Checked && cbbTimeUnit.SelectedIndex<0) 
                    || (rdbTrigger.Checked && (cbbTriggerService.SelectedIndex<0 || cbbTriggerState.SelectedIndex<0))
                    )
                {
                    sslEventInfo.Text = $"no event added, missing key parameter(s)";
                    Logger.Error("add event failed, missing key parameter(s)");
                    return;
                }

                String modeType = rdbTrigger.Checked? "Trigger":"Periodic";
                String procType = cbbProcess.SelectedItem.ToString();
                String ServiceName = cbbTargetService.SelectedItem.ToString();
                ServiceController ServiceController = new ServiceController(ServiceName);

                Int32 Interval;
                if(modeType == "Periodic")
                {
                    Int32 tUnit;
                    switch (cbbTimeUnit.SelectedItem.ToString())
                    {
                        case "Seconds": tUnit = 1000;  break;
                        case "Minutes": tUnit = 1000 * 60;  break;
                        case "Hours":   tUnit = 1000 * 60 * 60; break;
                        case "Days":    tUnit = 1000 * 60 * 60 * 24;    break;
                        default:        tUnit = 0;  break;
                    }
                    if (cbbTimeUnit.SelectedItem.ToString() == "Seconds" && Convert.ToInt32(nupInterval.Value) < 30)
                        MessageBox.Show("Interval less than 30 sec is not recommended!");
                    Interval = Convert.ToInt32(nupInterval.Value) * tUnit;
                }
                else
                    Interval = Setting.TriggerInterval;


                EventClass eAdd = new EventClass(myMaxID+1, false, modeType, procType, ServiceController, Interval);
                if(modeType == "Trigger")
                {
                    String TriggerServiceName = cbbTriggerService.SelectedItem.ToString();
                    if (TriggerServiceName == "same as target") TriggerServiceName = ServiceName;
                    EventClass.TriggerClass t = new EventClass.TriggerClass(TriggerServiceName, cbbTriggerState.SelectedItem.ToString());
                    eAdd.BindTrigger(t);
                }

                foreach (EventClass ev in myEventList)
                {
                    if (ev.myServiceController.ServiceName == eAdd.myServiceController.ServiceName)
                    {
                        Logger.Warn("two events with same service is not recommended");
                        MessageBox.Show("Two events with same service is not recommended!");
                    }
                }
                AddServiceEvent(eAdd);
                DisplayServiceEventList();

                sslEventInfo.Text = $"service ID[{eAdd.myID}] added";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                List<Int32> EventIDList = new List<Int32>();
                if (dgvEventView.SelectedRows.Count > 0)
                    foreach (DataGridViewRow r in dgvEventView.SelectedRows)
                        EventIDList.Add(Convert.ToInt32(r.Cells[0].Value));
                else if (dgvEventView.SelectedCells.Count > 0)
                    foreach (DataGridViewCell c in dgvEventView.SelectedCells)
                    {
                        DataGridViewRow r = dgvEventView.Rows[c.RowIndex];
                        EventIDList.Add(Convert.ToInt32(r.Cells[0].Value));
                    }
                else
                {
                    sslEventInfo.Text = $"no event removed, find no selection";
                    Logger.Error("remove event failed, find no selection");
                    return;
                }

                Int32 cnt = RemoveServiceEvents(EventIDList);

                DisplayServiceEventList();
                sslEventInfo.Text = $"{cnt} service(s) removed";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
            }


        }

        private void cbbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySelectedGroupName = cbbGroup.SelectedItem.ToString();
            
            cbbTargetService.Items.Clear();
            cbbTargetService.Text = "";
            cbbTriggerService.Items.Clear();
            cbbTriggerService.Text = "";

            foreach (GroupClass group in myServiceGroupList)
            {
                if (group.myGroupName == mySelectedGroupName && group.myServiceList.Count > 0)
                {
                    foreach (ServiceController sc in group.myServiceList)
                    {
                        cbbTargetService.Items.Add(sc.ServiceName);
                        cbbTriggerService.Items.Add(sc.ServiceName);
                    }
                }
            }
            cbbTriggerService.Items.Add("same as target");
            cbbTriggerService.SelectedIndex = cbbTriggerService.Items.Count - 1;
        }

        private void rdbPeriodic_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbPeriodic.Checked == true)
            {
                nupInterval.Enabled = true;
                cbbTimeUnit.Enabled = true;
            }
            else
            {
                nupInterval.Enabled = false;
                cbbTimeUnit.Enabled = false;
            }
        }

        private void rdbTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTrigger.Checked == true)
            {
                cbbTriggerService.Enabled = true;
                cbbTriggerState.Enabled = true;
            }
            else
            {
                cbbTriggerService.Text = "same as above";
                cbbTriggerService.Enabled = false;
                cbbTriggerState.Enabled = false;
            }
        }

        private void dgvEventView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewCell r in dgvEventView.SelectedCells)
            {
                Int32 id = r.RowIndex;
                myEventList[id].myEnable = Convert.ToBoolean(r.Value);
            }
        }

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SelectedGroup = mySelectedGroupName;
            Logger.Debug("Destroyed");
        }

        #endregion

        
    }
}
