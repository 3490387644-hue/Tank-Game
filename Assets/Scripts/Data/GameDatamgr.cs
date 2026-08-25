using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatamgr
{
    //采用单例模式
    private static GameDatamgr gameDatamgr=new GameDatamgr();
    public  static GameDatamgr Instance { get => gameDatamgr; }
    public MusicData musicData;
    public RankList rankList;
    private GameDatamgr()
    {
        //数据读取
        musicData = PlayerPrefsDataMgr.Instance.loaddata(typeof(MusicData), "Music") as MusicData;
        if (!musicData.notfirst)
        {
            musicData.Issound = true;
            musicData.Ismusic = true;
            musicData.soundvalue = 0.5f;
            musicData.musicvalue = 0.5f;
            musicData.notfirst = true;
            PlayerPrefsDataMgr.Instance.savedata(musicData, "Music");
        }
        rankList=PlayerPrefsDataMgr.Instance.loaddata(typeof(RankList),"Rank") as RankList;
    }

    //排行榜数据存储
    public void RankPrefs(string name,int score,float time)
    {
        rankList.list.Add(new RankDate(name,score,time));
        rankList.list.Sort((a, b) =>
        {
            return a.time < b.time ? -1 : 1;
        });
        for(int i=rankList.list.Count-1;i>=10;i--)
        {
            rankList.list.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.savedata(rankList, "Rank");
    }

    //音量开关
    public void IsSoundOpen(bool isopen)
    {
        musicData.Issound=isopen;
        BackGroundMusic.Music.soundopen(isopen);
        PlayerPrefsDataMgr.Instance.savedata(musicData, "Music");
    }
    //音效开关
    public void IsMusicOpen(bool isopen)
    {
        musicData.Ismusic = isopen;
        //BackGroundMusic.Music.musicopen(isopen);
        PlayerPrefsDataMgr.Instance.savedata(musicData, "Music");
    }
    //音量大小
    public void Sound(float str)
    {
        musicData.soundvalue=str;
        BackGroundMusic.Music.soundvalue(str);
        PlayerPrefsDataMgr.Instance.savedata(musicData, "Music");
    }
    //音效大小
    public void Music(float str)
    {
        musicData.musicvalue = str;
        //BackGroundMusic.Music.musicvalue(str);
        PlayerPrefsDataMgr.Instance.savedata(musicData, "Music");
    }
}
