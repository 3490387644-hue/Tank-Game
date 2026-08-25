using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //炮塔的子弹
    public GameObject bullet;
    //炮塔的炮口数量
    public Transform[] transforms;
    //炮塔发射炮弹间隔时间
    private float time = 1;
    //时间计算变量
    private float nowtime=0;

    // Update is called once per frame
    void Update()
    {
        nowtime += Time.deltaTime;
        if(nowtime > time)
        {
            fire();
            nowtime = 0;
        }
    }

    public override void fire()
    {
        for(int i=0;i<transforms.Length;i++)
        {
            GameObject a=Instantiate(bullet, transforms[i].position, transforms[i].rotation);
            BulletObj bulletObj = a.GetComponent<BulletObj>();
            bulletObj.setfather(this);
        }
    }

    public override void hurt(TankBaseObj other)
    {
        
    }
}
