using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateobj : MonoBehaviour
{
    public int RotateSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up,RotateSpeed*Time.deltaTime);
    }
}
