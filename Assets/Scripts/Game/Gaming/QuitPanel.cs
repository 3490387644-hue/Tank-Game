using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public ButtonControl btncloase;
    public ButtonControl btnquit;
    public ButtonControl btnback;
    void Start()
    {
        btncloase.OnClick += () =>
        {
            HideMe();
        };
        btnquit.OnClick += () =>
        {
            SceneManager.LoadScene("Start  Scene");
        };
        btnback.OnClick += () =>
        {
            HideMe();
        };
        HideMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
