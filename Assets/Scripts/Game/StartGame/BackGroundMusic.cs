using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private static BackGroundMusic music;
    public static BackGroundMusic  Music=>music;
    private AudioSource source;
    private void Awake()
    {
        source = this.gameObject.GetComponent<AudioSource>();
        music = this;
        soundvalue(GameDatamgr.Instance.musicData.soundvalue);
        soundopen(GameDatamgr.Instance.musicData.Issound);
    }
    public void soundvalue(float value)
    {
        source.volume = value;
    }
    public void soundopen(bool value)
    {
        source.mute=!value;
    }
}
