using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Root : MonoBehaviour
{
    private BaseControl[] baseControls;
    void Start()
    {
        baseControls = GetComponentsInChildren<BaseControl>();
    }

    private void OnGUI()
    {
        //编辑模式下会获取子对象的脚本，运行模式下则不会
        //if(!Application.isPlaying)
        baseControls = GetComponentsInChildren<BaseControl>();
        for(int i = 0; i < baseControls.Length; i++)
        {
            baseControls[i].DrawGUI();
        }
    }
}
