using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //坦克基础数据
    public int atk;
    public int def;
    public float maxhp;
    public float hp;
    //坦克移动旋转速度
    public int movespeed = 10;
    public int roundspeed = 100;
    public int headroundspeed = 100;
    //坦克炮台
    public GameObject tankhead;
    //坦克销毁特效预设体
    public GameObject end;
    //坦克开火相关
    public abstract void fire();
    //坦克受伤相关
    public virtual void hurt(TankBaseObj other)
    {
        float str = other.atk - def;
       if(str<=0)
       {
          return;
       }
       hp-=str;
        if(hp<=0)
        {
            hp = 0;
            die();
        }
    }
    //坦克死亡相关
    public virtual void die()
    {
        Destroy(this.gameObject);
        if(end!=null)
        {
            GameObject a = GameObject.Instantiate(end, this.transform.position, this.transform.rotation);
            AudioSource audioSource = a.GetComponent<AudioSource>();
            audioSource.volume = GameDatamgr.Instance.musicData.musicvalue;
            audioSource.mute=!GameDatamgr.Instance.musicData.Ismusic;
            audioSource.Play();
        }
    }
}
