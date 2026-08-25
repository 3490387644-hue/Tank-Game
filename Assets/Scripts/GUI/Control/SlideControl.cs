using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_Slide_Type
{
    horizontal,
    vertical,
}

public class SlideControl : BaseControl
{
    public float minvalue = 0;
    public float maxvalue = 1;
    public float nowvalue = 0;
    public GUIStyle button;
    public E_Slide_Type type= E_Slide_Type.horizontal;
    public event UnityAction<float> OnClick;
    private float oldvalue = 0;
    protected override void Setoff()
    {
        switch (type)
        {
            case E_Slide_Type.horizontal:
                nowvalue=GUI.HorizontalSlider(formBase.str,nowvalue,minvalue,maxvalue);
                if(oldvalue!=nowvalue)
                {
                    oldvalue = nowvalue;
                    OnClick.Invoke(oldvalue);
                }
                break;
            case E_Slide_Type.vertical:
                nowvalue = GUI.VerticalSlider(formBase.str, nowvalue, minvalue, maxvalue);
                if (oldvalue != nowvalue)
                {
                    oldvalue = nowvalue;
                    OnClick.Invoke(oldvalue);
                }
                break;
        }
    }
    protected override void Seton()
    {
        switch (type)
        {
            case E_Slide_Type.horizontal:
                nowvalue = GUI.HorizontalSlider(formBase.str, nowvalue, minvalue, maxvalue);
                if (oldvalue != nowvalue)
                {
                    OnClick.Invoke(oldvalue);
                    oldvalue = nowvalue;
                }
                break;
            case E_Slide_Type.vertical:
                nowvalue = GUI.VerticalSlider(formBase.str, nowvalue, minvalue, maxvalue,style,button);
                if (oldvalue != nowvalue)
                {
                    OnClick.Invoke(oldvalue);
                    oldvalue = nowvalue;
                }
                break;
        }
    }
}
