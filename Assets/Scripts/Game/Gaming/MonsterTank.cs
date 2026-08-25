using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTank : TankBaseObj
{
    //移动的目标点集
    public Transform[] transforms;
    //移动的目标点
    private Transform ranpos;
    //坦克的发射口
    public Transform[] shoot;
    //坦克装载的子弹
    public GameObject BulletObj;
    //间隔多少秒发射子弹
    public float BulletTime = 1;
    public float nowtime = 0;
    //玩家距离怪物多少距离时怪物自动攻击玩家
    public float distance = 10;
    //玩家对象
    public GameObject Player;
    //怪物血条图片
    public Texture maxhpbk;
    public Texture hpbk;
    //怪物血条坐标
    private Rect maxhprect;
    private Rect hprect;

    void Start()
    {
        Ranpos();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(ranpos);
        tankhead.transform.LookAt(Player.transform);
        this.transform.Translate(Vector3.forward*movespeed*Time.deltaTime);
        if(Vector3.Distance(this.transform.position,ranpos.position)<0.5f)
        {
            Ranpos();
        }
        nowtime += Time.deltaTime;
        if(Vector3.Distance(Player.transform.position,this.transform.position)<distance)
        {
            if (nowtime >= BulletTime)
            {
                fire();
                nowtime = 0;
            }
        }

    }

    private void OnGUI()
    {
        //怪物血条绘制
        Vector3 screenpos=Camera.main.WorldToScreenPoint(this.transform.position);
        hprect.x= screenpos.x-50;
        hprect.y=Screen.height-screenpos.y-60;
        maxhprect.x= screenpos.x - 50;
        maxhprect.y = Screen.height - screenpos.y - 60;
        hprect.width = 100;
        hprect.height = 15;
        maxhprect.width = 100;
        maxhprect.height= 15;
        hprect.width = (hp / maxhp) * hprect.width;
        GUI.DrawTexture(maxhprect, maxhpbk);
        GUI.DrawTexture(hprect, hpbk);
    }

    //为怪物设置随机的目标点
    private void Ranpos()
    {
        ranpos = transforms[Random.Range(0, transforms.Length)];
    }
    //重写怪物开火函数
    public override void fire()
    {
        for(int i=0;i<shoot.Length;i++)
        {
            GameObject str= Instantiate(BulletObj, shoot[i].position, shoot[i].rotation);
            BulletObj ptr= str.GetComponent<BulletObj>();
            ptr.setfather(this);
        }
    }
    //重写怪物死亡函数
    public override void die()
    {
        base.die();
        GameMainPanel.Instance.AddScore(10);
    }
}
