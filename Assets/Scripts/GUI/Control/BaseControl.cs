using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

//Style开关
public enum E_OnOff
{
    on,
    off,
}

public class BaseControl : MonoBehaviour
{
    public TransFormBase formBase;
    public GUIContent content;
    public GUIStyle style;
    public E_OnOff onOff=E_OnOff.off;
    public void DrawGUI()
    {
        switch (onOff)
        {
            case E_OnOff.off:
                Setoff();
                break;
            case E_OnOff.on:
                Seton();
                break;
        }
    }
    //当Style设置关闭时
    protected virtual void Setoff()
    {
    }
    //当Style设置开启时
    protected virtual void Seton()
    {
    }
    
}
