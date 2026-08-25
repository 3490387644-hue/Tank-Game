using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] str;
    public TankBaseObj fathertank;

    public void setfather(TankBaseObj obj)
    {
        fathertank = obj;
    }
    public void fire()
    {
        for(int i=0;i<str.Length;i++)
        {
            GameObject.Instantiate(bullet, str[i].position, str[i].rotation);
            BulletObj bulletObj=bullet.GetComponent<BulletObj>();
            bulletObj.setfather(fathertank);
        }
    }
}
