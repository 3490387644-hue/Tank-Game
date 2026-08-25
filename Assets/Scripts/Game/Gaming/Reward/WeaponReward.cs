using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public WeaponObj[] weaponObjs;
    public GameObject GetEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int index=UnityEngine.Random.Range(0, weaponObjs.Length);
            PlayerTank playerTank=other.GetComponent<PlayerTank>();
            playerTank.ChangeWeapon(weaponObjs[index]);
            //控制特效的音效
            GameObject str =Instantiate(GetEffect,this.transform.position,this.transform.rotation);
            AudioSource source = str.GetComponent<AudioSource>();
            source.volume=GameDatamgr.Instance.musicData.musicvalue;
            source.mute=!GameDatamgr.Instance.musicData.Ismusic;
            Destroy(this.gameObject);
        }
    }
}
