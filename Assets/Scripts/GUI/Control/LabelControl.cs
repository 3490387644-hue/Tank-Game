using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelControl:BaseControl
{
    protected override void Setoff()
    {
        GUI.Label(formBase.str, content);
    }
    protected override void Seton()
    {
        GUI.Label(formBase.str, content,style);
    }
}
