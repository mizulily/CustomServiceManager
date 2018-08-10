using System;
using System.Collections.Generic;
using System.Linq;

using System.ServiceProcess;

namespace CustomServiceManager
{
    class GroupClass
    {
        public String myGroupName;
        public List<ServiceController> myServiceList;

        public GroupClass(String appSettingString)
        {
            String[] StrRaw = appSettingString.Split(',');

            myGroupName = StrRaw[0];

            List<String> ServiceNameList = StrRaw.ToList();
            ServiceNameList.RemoveAt(0);

            myServiceList = new List<ServiceController>();
            foreach (String ServiceName in ServiceNameList)
                myServiceList.Add(new ServiceController(ServiceName));
        }

        public GroupClass(String GroupName, List<ServiceController> ServiceList)
        {
            myGroupName = GroupName;
            myServiceList = ServiceList;
        }

        // Add Single Service to this group. Check duplication.
        public Boolean AddService(ServiceController Service)
        {
            foreach(ServiceController sc in myServiceList)
                if (sc.ServiceName == Service.ServiceName) return false;

            myServiceList.Add(Service);
            return true;
        }

        // Remove Single Service to this group. Check existence
        public Boolean RemoveService(ServiceController Service)
        {
            foreach (ServiceController sc in myServiceList)
            {
                if (sc.ServiceName == Service.ServiceName)
                {
                    myServiceList.Remove(sc);
                    return true;
                }
            }
            return false;
        }

        // appSetting Info ToString
        public String appSettingString()
        {
            List<String> str = new List<String>();
            str.Add(myGroupName);
            foreach (ServiceController sc in myServiceList)
                str.Add(sc.ServiceName);
            return String.Join(",", str);
        }
    }
}
