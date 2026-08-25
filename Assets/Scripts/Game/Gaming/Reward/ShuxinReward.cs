using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Shuxin
{
    maxhp,
    hp,
    atk,
    def,
    bulletspeed
}
public class ShuxinReward : MonoBehaviour
{
    public E_Shuxin shuxin;
    public GameObject GetEffect;
    //子弹预设体
    public GameObject bullet1;
    public GameObject bullet2;
    public int addvalue;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TankBaseObj player=other.GetComponent<TankBaseObj>();
            switch (shuxin)
            {
                case E_Shuxin.maxhp:
                    player.maxhp += addvalue;
                    
                    //更新血条
                    GameMainPanel.Instance.updatehp(player.maxhp, player.hp);
                    break;
                case E_Shuxin.hp:
                    player.hp += addvalue;
                    if (player.hp > player.maxhp)
                    {
                        player.hp = player.maxhp;
                    }
                    //更新血条
                    GameMainPanel.Instance.updatehp(player.maxhp, player.hp);
                    break;
                case E_Shuxin.atk:
                    player.atk += addvalue;
                    break;
                case E_Shuxin.def:
                    player.def += addvalue;
                    break;
                case E_Shuxin.bulletspeed:
                    BulletObj bulletobj1=bullet1.GetComponent<BulletObj>();
                    BulletObj bullettobj2=bullet2.GetComponent<BulletObj>();
                    bulletobj1.movespeed += 10;
                    bullettobj2.movespeed += 10;
                    break;
            }
            //控制特效的音效
            GameObject str = Instantiate(GetEffect, this.transform.position, this.transform.rotation);
            AudioSource source = str.GetComponent<AudioSource>();
            source.volume = GameDatamgr.Instance.musicData.musicvalue;
            source.mute = !GameDatamgr.Instance.musicData.Ismusic;
            Destroy(this.gameObject);
        }
    }
}
