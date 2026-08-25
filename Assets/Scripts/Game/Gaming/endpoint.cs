using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endpoint : MonoBehaviour
{
    public BulletObj bulletObj;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            bulletObj.movespeed = 20;
            Time.timeScale = 0;
            WinPanel.ptr.ShowMe();
        }
    }
}
