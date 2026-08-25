using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureConsole :BaseControl
{
    public Texture texture;
    public ScaleMode scaleMode=ScaleMode.StretchToFill;
    protected override void Setoff()
    {
        GUI.DrawTexture(formBase.str, texture,scaleMode);
    }
    protected override void Seton()
    {
        GUI.DrawTexture(formBase.str, texture,scaleMode);
    }
}
