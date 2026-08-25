using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public int movespeed = 10;
    public TankBaseObj obj;
    public GameObject boom;
    public void setfather(TankBaseObj obj1)
    {
        obj = obj1;
    }

    private void Update()
    {
        this.gameObject.transform.Translate(Vector3.forward* movespeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube")||other.CompareTag("Monster")&&obj.CompareTag("Player")||
            other.CompareTag("Player") && obj.CompareTag("Monster"))
        {
            TankBaseObj baseObj=other.GetComponent<TankBaseObj>();
            if (baseObj!=null)
            {
                baseObj.hurt(obj);
            }
            if(boom != null)
            {
                GameObject.Instantiate(boom,this.transform.position,this.transform.rotation);
                AudioSource audioSource=boom.GetComponent<AudioSource>();
                audioSource.volume = GameDatamgr.Instance.musicData.musicvalue;
                audioSource.mute = !GameDatamgr.Instance.musicData.Ismusic;
            }
            Destroy(boom);
            Destroy(this.gameObject);
        }
    }
}
