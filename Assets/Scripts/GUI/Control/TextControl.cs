using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextControl : BaseControl
{
    public  event UnityAction<string> ptr;
    private string oldtext="";
    protected override void Setoff()
    {
        content.text=GUI.TextField(formBase.str,content.text);
        if(oldtext!=content.text)
        {
            ptr.Invoke(oldtext);
            oldtext=content.text;
        }
    }
    protected override void Seton()
    {
        content.text = GUI.TextField(formBase.str, content.text,style);
        if (oldtext != content.text)
        {
            ptr.Invoke(oldtext);
            oldtext = content.text;
        }
    }
}
