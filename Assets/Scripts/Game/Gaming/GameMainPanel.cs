using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainPanel : MonoBehaviour
{
    //提供的外部接口
    private static GameMainPanel instance;
    public static GameMainPanel Instance=>instance;

    public LabelControl labscore;
    public LabelControl labtime;
    public ButtonControl btnsetting;
    public ButtonControl btnquit;
    public TextureConsole testhp;
    [HideInInspector]
    public int nowscore = 0;
    [HideInInspector]
    public float nowtime = 0;
    private int qtr;
    //记录原来血条宽
    private float hpp;
    void Start()
    {
        hpp = testhp.formBase.c_kuang;
        instance = this;
        btnsetting.OnClick += () =>
        {
            Time.timeScale = 0;
            SettingPanel.ptr.ShowMe();
        };
        btnquit.OnClick += () =>
        {
            Time.timeScale = 0;
            QuitPanel.ptr.ShowMe();
        };
    }

    //时间的计算
    void Update()
    {
        nowtime += Time.deltaTime;
        qtr = (int)nowtime;
        labtime.content.text ="";
        if (qtr / 3600 > 0)
        {
            labtime.content.text += qtr / 3600 + "时";
        }
        if (qtr % 3600 / 60 > 0 || labtime.content.text != "")
        {
            labtime.content.text += qtr % 3600 / 60 + "分";
        }
        labtime.content.text += qtr % 60 + "秒";
    }
    //提供的得到分数的方法
    public void AddScore(int getscore)
    {
        nowscore+= getscore;
        labscore.content.text=nowscore.ToString();
    }
    //提供的血量削减的API
    public void updatehp(float maxhp,float nowhp)
    {
        testhp.formBase.c_kuang = nowhp / maxhp * hpp;
    }
}
