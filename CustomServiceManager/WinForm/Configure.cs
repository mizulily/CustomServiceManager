using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.ServiceProcess;
using log4net;


namespace CustomServiceManager
{

    public partial class Configure : Form
    {
        private readonly ILog Logger = LogManager.GetLogger(typeof(Configure));

        private String mySelectedGroupName = Program.SelectedGroup;

        private ServiceController[] myServiceAllList;
        private List<GroupClass> myServiceGroupList;
        

        public Configure()
        {
            InitializeComponent();

            myServiceGroupList = Setting.LoadGroupList();

            if (!LoadServiceAllList())
            {
                sslSettingInfo.Text = "Load Windows services faile. Please refresh...";
            }
            DisplayServiceAllList();

            if (!LoadServiceGroupList())
            {
                myServiceGroupList = new List<GroupClass>();
            }
            DisplayServiceGroupList();

            InitializeEvent();

            sslSettingInfo.Text = $"Configuration loaded at {DateTime.Now.ToString("HH:mm:ss")}";
            Logger.Debug("Initialized");

        }

        #region UI Irrelevant Methods: Load/Save

        private Boolean LoadServiceAllList()
        {
            try
            {
                myServiceAllList = ServiceController.GetServices();
                Logger.Debug("Loaded windows service list");
                return true;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
                return false;
            }
        }

        // Load: appSetting -> myServiceGroupList
        // Save: myServiceGroupList -> appSetting
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

        private Boolean SaveServiceGroupList()
        {
            try
            {
                Setting.SaveGroupList(myServiceGroupList);
                Logger.Debug("Saved service group list to appSetting");
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
        private void ClearServiceGroupList()
        {
            myServiceGroupList.Clear();
            myServiceGroupList.Add(new GroupClass("Default", new List<ServiceController>()));
            mySelectedGroupName = "Default";
            Logger.Info("All groups and services are cleared");
        }

        private Boolean AddServiceGroup(String GroupName)
        {
            foreach (GroupClass g in myServiceGroupList)
            {
                if (g.myGroupName == GroupName)
                {
                    Logger.Error($"Attempted to add existed group {GroupName}");
                    return false;
                }
                else
                {
                    myServiceGroupList.Add(new GroupClass(GroupName, new List<ServiceController>()));
                    mySelectedGroupName = GroupName;
                    Logger.Info($"New group '{GroupName}' added to group list");
                }
                break;
            }
            return true;
        }

        private Int32 AddServices(String GroupName, List<ServiceController> ControllerList)
        {
            Int32 cnt = 0;

            foreach (GroupClass g in myServiceGroupList)
            {
                if (g.myGroupName == GroupName)
                {
                    foreach (ServiceController sc in ControllerList)
                        if (g.AddService(sc))
                            cnt++;
                    break;
                }
            }
            Logger.Info($"{cnt} service(s) added to group '{GroupName}'");
            return cnt;
                  
        }

        private Int32 RemoveServices(String GroupName, List<ServiceController> ControllerList)
        {
            Int32 cnt = 0;

            foreach (GroupClass g in myServiceGroupList)
            {
                if (g.myGroupName == GroupName)
                {
                    foreach (ServiceController sc in ControllerList)
                        if (g.RemoveService(sc))
                            cnt++;
                    break;
                }
            }
            Logger.Info($"{cnt} service(s) removed from group '{GroupName}'");
            return cnt;
            
        }

        //private Boolean IsServiceInstalled(String Name)
        //{
        //    foreach(ServiceController sc in myServiceAllList)
        //    {
        //        if (sc.ServiceName == Name || sc.DisplayName == Name) return true;
        //    }
        //    return false;
        //}
        #endregion

        #region UI Relevant Methods
        private void DisplayServiceAllList()
        {
            lsbServList.Items.Clear();
            txbServName.AutoCompleteCustomSource.Clear();

            foreach (ServiceController c in myServiceAllList)
            {
                if (c.Status == ServiceControllerStatus.Stopped && ckbStopped.Checked ||
                    c.Status == ServiceControllerStatus.Paused && ckbPaused.Checked ||
                    c.Status == ServiceControllerStatus.Running && ckbRunning.Checked)
                {
                    if (rdbServName.Checked)
                    {
                        lsbServList.Items.Add($"{c.ServiceName}:[{c.Status.ToString()}]");
                        txbServName.AutoCompleteCustomSource.Add(c.ServiceName);
                    }
                    else if (rdbDispName.Checked)
                    {
                        lsbServList.Items.Add($"{c.DisplayName}:[{c.Status.ToString()}]");
                        txbServName.AutoCompleteCustomSource.Add(c.DisplayName);
                    }
                }
            }
            sslSettingInfo.Text = $"Windows Service List updated at {DateTime.Now.ToString("HH:mm:ss")}";
               
        }

        private void DisplayServiceGroupList()
        {
            cbbServGroup.Items.Clear();
            lsbGroupList.Items.Clear();

            foreach (GroupClass group in myServiceGroupList)
            {
                cbbServGroup.Items.Add(group.myGroupName);
                if (group.myGroupName == mySelectedGroupName && group.myServiceList.Count > 0)
                {
                    foreach (ServiceController sc in group.myServiceList)
                        lsbGroupList.Items.Add(sc.ServiceName + '/' + sc.DisplayName);
                }
            }
            cbbServGroup.Items.Add("...");
            cbbServGroup.SelectedItem = mySelectedGroupName;
        }
        #endregion

        #region Event Handlers

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (LoadServiceAllList())
                DisplayServiceAllList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearServiceGroupList();
            DisplayServiceGroupList();
            sslSettingInfo.Text = $"All groups and services are cleared";
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            if (LoadServiceGroupList())
            {
                DisplayServiceGroupList();
                sslSettingInfo.Text = $"Configured Service List reloaded from appSetting at {DateTime.Now.ToString("HH:mm:ss")}";
            }
            else
                sslSettingInfo.Text = $"Configured Service List reloaded from appSetting failed";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveServiceGroupList();
            sslSettingInfo.Text = $"Configured Service List saved to appSetting at {DateTime.Now.ToString("HH:mm:ss")}";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                List<ServiceController> ServList = new List<ServiceController>();
                foreach (object obj in lsbServList.SelectedItems)
                {
                    String[] sl = obj.ToString().Split(':');
                    ServiceController sc = new ServiceController(sl[0]);
                    ServList.Add(sc);
                }

                Int32 cnt = AddServices(mySelectedGroupName, ServList);

                DisplayServiceGroupList();
                sslSettingInfo.Text = $"{cnt} service(s) added to group '{mySelectedGroupName}'";
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
            }
            
        }

        private void btnAddCustom_Click(object sender, EventArgs e)
        {
            try
            {
                String ServiceName = txbServName.Text;

                List<ServiceController> ServList = new List<ServiceController>();
                ServiceController sc = new ServiceController(ServiceName);
                ServList.Add(sc);
                Int32 cnt = AddServices(mySelectedGroupName, ServList);

                DisplayServiceGroupList();
                sslSettingInfo.Text = $"{cnt} service(s) added to group '{mySelectedGroupName}'";
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
                List<ServiceController> ServList = new List<ServiceController>();
                foreach (object obj in lsbGroupList.SelectedItems)
                {
                    String[] sl = obj.ToString().Split('/');
                    ServList.Add(new ServiceController(sl[0]));
                }

                Int32 cnt = RemoveServices(mySelectedGroupName, ServList);

                DisplayServiceGroupList();
                sslSettingInfo.Text = $"{cnt} service(s) removed from group '{mySelectedGroupName}'";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Exception");
                Logger.Error($"Exception: {err.Message}");
            }

        }


        private void cbbServGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItemString = cbbServGroup.SelectedItem.ToString();
            if (selectedItemString == "...")
            {
                cbbServGroup.DropDownStyle = ComboBoxStyle.DropDown;
                lsbGroupList.Items.Clear();
                cbbServGroup.Text = "";
                
            }
            else
            {
                cbbServGroup.DropDownStyle = ComboBoxStyle.DropDownList;
                mySelectedGroupName = selectedItemString;
                
                lsbGroupList.Items.Clear();
                foreach (GroupClass group in myServiceGroupList)
                {
                    if (group.myGroupName == mySelectedGroupName && group.myServiceList.Count > 0)
                    {
                        foreach (ServiceController sc in group.myServiceList)
                            lsbGroupList.Items.Add(sc.ServiceName + '/' + sc.DisplayName);
                    }
                }
            }
        }

        private void cbbServGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if(cbbServGroup.DropDownStyle == ComboBoxStyle.DropDown && e.KeyCode == Keys.Enter)
            {
                
                String GroupName = cbbServGroup.Text;
                if (GroupName != "" && GroupName != "...")
                {
                    AddServiceGroup(GroupName);
                    cbbServGroup.Items.Insert(cbbServGroup.Items.Count - 1, GroupName);
                    cbbServGroup.SelectedItem = GroupName;
                    sslSettingInfo.Text = $"New group '{GroupName}' added to group list";
                }
                else
                    cbbServGroup.SelectedItem = "Default";

                cbbServGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void Configure_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbbServGroup.DropDownStyle == ComboBoxStyle.DropDownList)
                mySelectedGroupName  = cbbServGroup.SelectedItem.ToString();
            else
                mySelectedGroupName = "Default";

            Program.SelectedGroup = mySelectedGroupName;
            Logger.Debug("Destroyed");
        }

        #endregion


    }
}
