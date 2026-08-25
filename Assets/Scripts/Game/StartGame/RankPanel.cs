using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RankPanel :BasePanel<RankPanel>
{
    public ButtonControl btn;
    private List<LabelControl> PLY = new List<LabelControl>();
    private List<LabelControl> SCORE = new List<LabelControl>();
    private List<LabelControl> TIME = new List<LabelControl>();
    void Start()
    {
        btn.OnClick += () =>
        {
            HideMe();
            StartPanel.ptr.ShowMe();
        };
        for (int i = 2; i <= 11; i++)
        {
            PLY.Add(this.transform.Find("RankPLY/LablePly" + i).GetComponent<LabelControl>());
            SCORE.Add(this.transform.Find("RankSCR/LableScore" + i).GetComponent<LabelControl>());
            TIME.Add(this.transform.Find("RankTIME/LableTime" + i).GetComponent<LabelControl>());
        }
        HideMe ();
    }

    public void UpdatePanel()
    {
        RankList list1 = PlayerPrefsDataMgr.Instance.loaddata(typeof(RankList), "Rank") as RankList;
        for(int i=0;i<list1.list.Count;i++)
        {
            PLY[i].content.text = list1.list[i].name;
            SCORE[i].content.text=list1.list[i].score.ToString();
            TIME[i].content.text = "";
            int qtr=(int)list1.list[i].time;
            if(qtr/3600>0)
            {
                TIME[i].content.text += qtr / 3600 + " ±";
            }
            if(qtr%3600/60>0|| TIME[i].content.text!="")
            {
                TIME[i].content.text += qtr % 3600 / 60 + "∑÷";
            }
            TIME[i].content.text += qtr%60 + "√Î";
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanel();
    }
}
