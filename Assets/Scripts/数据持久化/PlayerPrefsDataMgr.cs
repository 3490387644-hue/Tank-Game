using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsDataMgr
{
    //设置为静态变量可以使其长期使用且不用在其他脚本中初始化这个变量
    private static PlayerPrefsDataMgr instance=new PlayerPrefsDataMgr();
    //提供给外面获得instance的渠道
    public static PlayerPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }
    private PlayerPrefsDataMgr()
    {

    }
    //数据存储
    public void savedata(object str,string keyname)
    {
        Type type = str.GetType();
        FieldInfo[] infos= type.GetFields();
        string savename = "";
        for(int i = 0; i < infos.Length; i++)
        {
            FieldInfo ptr = infos[i];
            savename = keyname + "_" + type.Name + "_" + infos[i].FieldType.Name+"_"+infos[i].Name;
            saveall(ptr.GetValue(str), savename);
            PlayerPrefs.Save();
        }
    }
    //通过PlayerPrefs进行数据存储
    private void saveall(object value,string keyname)
    {
        Type type=value.GetType();
        if(type==typeof(int))
        {
            PlayerPrefs.SetInt(keyname, (int)value);
        }
        else if(type==typeof(float))
        {
            PlayerPrefs.SetFloat(keyname, (float)value);
        }
        else if(type==typeof(string))
        {
            PlayerPrefs.SetString(keyname, value.ToString());
        }
        else if(type==typeof(bool))
        {
            PlayerPrefs.SetInt(keyname, (bool)value ? 1 : 0);
        }
        //IList是List的父类，这里用父类装子类，即采用里氏替换原则
        else if(typeof(IList).IsAssignableFrom(type))
        {
            IList list = value as IList;
            PlayerPrefs.SetInt(keyname, list.Count);
            int index = 0;
            for(int i=0;i<list.Count;i++)
            {
                saveall(list[i], keyname+index);
                index++;
            }
        }
        //IDictionary是Dictionary的父类，这里用父类装子类，即采用里氏替换原则
        else if (typeof(IDictionary).IsAssignableFrom(type))
        {
            IDictionary dic = value as IDictionary;
            PlayerPrefs.SetInt(keyname, dic.Count);
            int index = 0;
            foreach (object obj in dic.Keys)
            {
                saveall(obj, keyname + "_Key_" + index);
                saveall(dic[obj], keyname + "_Value_" + index);
                index++;
            }
        }
        else
        {
            savedata(value, keyname);
        }
    }
    //数据读取
    public object loaddata(Type type,string keyname)
    {
        object data=Activator.CreateInstance(type);
        FieldInfo[] fields = type.GetFields();
        string loadname = "";
        FieldInfo info;
        for(int i=0;i<fields.Length;i++)
        {
            info = fields[i];
            loadname= keyname + "_" + type.Name + "_" + fields[i].FieldType.Name + "_" + fields[i].Name;
            info.SetValue(data, Loadall(info.FieldType,loadname));
        }
        return data;
    }
    private object Loadall(Type type,string keyname)
    {
        if (type == typeof(int))
        {
            return PlayerPrefs.GetInt(keyname);
        }
        else if (type == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyname);
        }
        else if (type == typeof(string))
        {
            return PlayerPrefs.GetString(keyname);
        }
        else if (type == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyname)==1?true:false;
        }
        else if(typeof(IList).IsAssignableFrom(type))
        {
            int count=PlayerPrefs.GetInt(keyname, 0);
            IList list = Activator.CreateInstance(type) as IList;
            for(int i=0;i<count;i++)
            {
                list.Add(Loadall(type.GetGenericArguments()[0], keyname + i));
            }
            return list;
        }
        else if(typeof(IDictionary).IsAssignableFrom(type))
        {
            IDictionary dictionary = Activator.CreateInstance(type) as IDictionary;
            int count = PlayerPrefs.GetInt(keyname, 0);
            Type[] types = type.GetGenericArguments();
            for(int i=0;i<count;i++)
            {
                dictionary.Add(Loadall(types[0], keyname + "_Key_" + i), Loadall(types[1], keyname + "_Value_" + i));
            }
            return dictionary;
        }
        else
        {
            return loaddata(type, keyname);
        }
    }
}
