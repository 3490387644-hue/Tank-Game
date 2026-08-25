using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : BaseControl
{
    public event UnityAction OnClick;
    protected override void Setoff()
    {
        if(GUI.Button(formBase.str, content))
        {
            OnClick.Invoke();
        }
    }
    protected override void Seton()
    {
        if(GUI.Button(formBase.str, content, style))
        {
            OnClick.Invoke();
        }
    }
}
