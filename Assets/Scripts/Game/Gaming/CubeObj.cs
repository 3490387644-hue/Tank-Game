using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewards;
    public GameObject DestoryReward;
    //方块血量
    public int hp = 10;
    //用于存放子弹对象
    private BulletObj bulletObj;
    private void OnTriggerEnter(Collider other)
    {
        bulletObj = other.GetComponent<BulletObj>();
        if(bulletObj.obj.CompareTag("Player"))
        {
            hp -= bulletObj.obj.atk;
            if (hp <= 0)
            {
                int gailv = Random.Range(0, 100);
                if (gailv <= 60)
                {
                    //随机获取奖励
                    int str = Random.Range(0, rewards.Length);
                    GameObject.Instantiate(rewards[str], this.transform.position, this.transform.rotation);
                }
                GameObject ptr = Instantiate(DestoryReward, this.transform.position, this.transform.rotation);
                AudioSource audioSource = ptr.GetComponent<AudioSource>();
                audioSource.volume = GameDatamgr.Instance.musicData.musicvalue;
                audioSource.mute = !GameDatamgr.Instance.musicData.Ismusic;
                Destroy(this.gameObject);
            }
        }
    }
}
