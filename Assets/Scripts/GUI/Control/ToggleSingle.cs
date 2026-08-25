using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSingle : MonoBehaviour
{
    public ToggleControl[] toggle;
    private ToggleControl lastptr;
    void Start()
    {
        if(toggle.Length==0)
        {
            return;
        }
        for(int i=0;i<toggle.Length;i++)
        {
           ToggleControl ptr=toggle[i];
            ptr.OnClick += (value) =>
            {
                if (value)
                {
                    for (int j = 0; j < toggle.Length; j++)
                    {
                        if (toggle[j] != ptr)
                        {
                            toggle[j].istrue = false;
                        }
                    }
                    lastptr= ptr;
                }
                else
                {
                    if (lastptr == ptr)
                    {
                        ptr.istrue = true;
                    }
                }
            };
        }
    }
}
