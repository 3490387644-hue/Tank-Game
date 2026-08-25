using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleControl : BaseControl
{
    public bool istrue;
    private bool oldtrue;
    public UnityAction<bool> OnClick;
    protected override void Setoff()
    {
        istrue = GUI.Toggle(formBase.str, istrue,content);
        if(oldtrue!=istrue)
        {
            OnClick.Invoke(istrue);
            oldtrue = istrue;
        }
    }
    protected override void Seton()
    {
        istrue = GUI.Toggle(formBase.str, istrue, content,style);
        if (oldtrue != istrue)
        {
            OnClick.Invoke(istrue);
            oldtrue = istrue;
        }
    }
}
