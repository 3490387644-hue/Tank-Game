using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T:class
{
    private static T str;
    public static T ptr
    {
        get 
        {
           return str;
        }
    }

    private void Awake()
    {
        str = this as T; 
    }
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
