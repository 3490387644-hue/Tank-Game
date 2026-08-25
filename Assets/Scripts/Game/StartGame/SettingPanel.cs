using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public ButtonControl quitbtn;
    public SlideControl SoundSld;
    public SlideControl MusicSld;
    public ToggleControl toggleSound;
    public ToggleControl toggleMusic;
    void Start()
    {
        //返回按钮
        quitbtn.OnClick += () =>
        {
            HideMe();
            if(SceneManager.GetActiveScene().name== "Start  Scene")
            {
                StartPanel.ptr.ShowMe();
            }
        };
        //控制音量大小
        SoundSld.OnClick += (value) =>
        {
            GameDatamgr.Instance.Sound(value);
        };
        //控制音效大小
        MusicSld.OnClick += (value) =>
        {
            GameDatamgr.Instance.Music(value);
        };
        //音乐开关
        toggleSound.OnClick += (value) =>
        {
            GameDatamgr.Instance.IsSoundOpen(value);
        };
        //音效开关
        toggleMusic.OnClick += (value) =>
        {
            GameDatamgr.Instance.IsMusicOpen(value);
        };
        HideMe ();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }

    public void UpdatePanel()
    {
        MusicData date = GameDatamgr.Instance.musicData;
        toggleSound.istrue=date.Issound;
        toggleMusic.istrue=date.Ismusic;
        SoundSld.nowvalue=date.soundvalue;
        MusicSld.nowvalue = date.musicvalue;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanel();
    }
}
