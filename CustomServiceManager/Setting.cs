using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;


namespace CustomServiceManager
{
    static class Setting
    {
        private enum SettingOperationRawType {ADD, REMOVE, UPDATE};

        static public Int32 TriggerInterval;
        static public void Initialize()
        {
            TriggerInterval = Convert.ToInt32(ConfigurationManager.AppSettings["TriggerInterval"]);
        }

        
        #region GroupList Operation
        static public List<GroupClass> LoadGroupList()
        {
            List<GroupClass> groups = new List<GroupClass>();

            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Int32 GroupCnt = Convert.ToInt32(loadItem(cfg, "GroupCnt"));
            List<String> GroupInfoList = loadItems(cfg, "Group", Enumerable.Range(1, GroupCnt));

            foreach (String GroupInfo in GroupInfoList)
                groups.Add(new GroupClass(GroupInfo));

            return groups;
        }

        static public void SaveGroupList(List<GroupClass> groups)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            RemoveGeneralSettingList(cfg, "GroupCnt", "Group");

            List<String> GroupInfoList = new List<String>();
            foreach (GroupClass group in groups)
                GroupInfoList.Add(group.appSettingString());

            AddGeneralSettingList(cfg, "GroupCnt", "Group", GroupInfoList);
        }

        #endregion


        #region EventList Operation
        static public List<EventClass> LoadEventList()
        {
            List<EventClass> events = new List<EventClass>();

            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Int32 EventCnt = Convert.ToInt32(loadItem(cfg, "EventCnt"));
            List<String> EventInfoList = loadItems(cfg, "Event", Enumerable.Range(1, EventCnt));

            foreach (String EventInfo in EventInfoList)
                events.Add(new EventClass(EventInfo));

            return events;
        }

        static public void SaveEventList(List<EventClass> events)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            RemoveGeneralSettingList(cfg, "EventCnt", "Event");

            List<String> EventInfoList = new List<String>();
            foreach (EventClass eventc in events)
                EventInfoList.Add(eventc.appSettingString());
            AddGeneralSettingList(cfg, "EventCnt", "Event", EventInfoList);
        }
        #endregion

        #region Project Methods

        static private void AddGeneralSettingList(Configuration cfg, String cntItemStr, String indItemStr, List<String> appSettingStrs)
        {
            oprItem(cfg, SettingOperationRawType.ADD, cntItemStr, Convert.ToString(appSettingStrs.Count));
            oprItems(cfg, SettingOperationRawType.ADD, indItemStr, Enumerable.Range(1, appSettingStrs.Count), appSettingStrs);
        }

        static private void RemoveGeneralSettingList(Configuration cfg, String cntItemStr, String indItemStr)
        {
            Int32 ItemCnt = Convert.ToInt32(loadItem(cfg, cntItemStr));
            oprItem(cfg, SettingOperationRawType.REMOVE, cntItemStr);
            oprItems(cfg, SettingOperationRawType.REMOVE, indItemStr, Enumerable.Range(1, ItemCnt));
        }
        #endregion

        #region Generic Methods
        static private Boolean oprItem(Configuration cfg, SettingOperationRawType tp, String keyName, String keyValue = null)
        {
            switch (tp)
            {
                case SettingOperationRawType.ADD:
                    if (existItem(keyName)) return false;
                    cfg.AppSettings.Settings.Add(keyName, keyValue);    break;
                case SettingOperationRawType.REMOVE:
                    if (!existItem(keyName)) return false;
                    cfg.AppSettings.Settings.Remove(keyName);   break;
                case SettingOperationRawType.UPDATE:
                    if (!existItem(keyName)) return false;
                    cfg.AppSettings.Settings[keyName].Value = keyValue; break;
                default:
                    return false;
            }
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            return true;
        }

        static private String loadItem(Configuration cfg, String keyName)
        {
            if (!existItem(keyName)) return null;
            return cfg.AppSettings.Settings[keyName].Value;
        }

        static private Boolean oprItems(Configuration cfg, SettingOperationRawType tp, String indexName, IEnumerable<Int32> indexValues, List<String> keyValues = null)
        {
            //if ((indexValues.Count != keyValues.Count) && keyValues == null) return false;
            //int i = indexValues.Count<IEnumerable>;
            foreach (Int32 i in indexValues)
            {
                String keyName = indexName + Convert.ToString(i);
                String keyValue;
                switch (tp)
                {
                    case SettingOperationRawType.ADD:
                        if (existItem(keyName)) return false;
                        keyValue = keyValues[i-1];
                        cfg.AppSettings.Settings.Add(keyName, keyValue);
                        break;
                    case SettingOperationRawType.REMOVE:
                        if (!existItem(keyName)) return false;
                        cfg.AppSettings.Settings.Remove(keyName);
                        break;
                    case SettingOperationRawType.UPDATE:
                        if (!existItem(keyName)) return false;
                        keyValue = keyValues[i-1];
                        cfg.AppSettings.Settings[keyName].Value = keyValue;
                        break;
                    default:
                        return false;
                }
            }
            
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            return true;
        }

        static private List<String> loadItems(Configuration cfg, String indexName, IEnumerable<Int32> indexValues)
        {
            List<String> keyValues = new List<String>();
            foreach (Int32 i in indexValues)
            {
                String keyName = indexName + Convert.ToString(i);
                if (!existItem(keyName)) return new List<String>();
                keyValues.Add(cfg.AppSettings.Settings[keyName].Value);
            }
            return keyValues;
        }


        static private Boolean existItem(String keyName)
        {
            foreach(String key in ConfigurationManager.AppSettings)
            {
                if (key == keyName) return true;
            }
            return false;
        }

        #endregion
    }
}
