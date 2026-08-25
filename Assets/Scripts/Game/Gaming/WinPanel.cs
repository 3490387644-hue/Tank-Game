using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public TextControl text;
    public ButtonControl button;
    void Start()
    {
        button.OnClick += () =>
        {
            Time.timeScale = 1;
            GameDatamgr.Instance.RankPrefs(text.content.text,GameMainPanel.Instance.nowscore,GameMainPanel.Instance.nowtime);
            SceneManager.LoadScene("Start  Scene");
        };
        HideMe();
    }
}
