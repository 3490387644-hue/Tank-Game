using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapphoto : MonoBehaviour
{
    public Transform obj;
    public int high;
    private Vector3 pos;
    private void LateUpdate()
    {
        pos.x = obj.position.x;
        pos.y = high;
        pos.z = obj.position.z;
        if (obj == null)
            return;
        this.transform.position = pos;
    }
}
