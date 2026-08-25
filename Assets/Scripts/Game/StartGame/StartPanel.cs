using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : BasePanel<StartPanel>
{
    public ButtonControl StartBtn;
    public ButtonControl SettingBtn;
    public ButtonControl QuitBtn;
    public ButtonControl RankBtn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        StartBtn.OnClick += () =>
        {
            SceneManager.LoadScene("Game  Scene");
        };
        SettingBtn.OnClick += () =>
        {
            SettingPanel.ptr.ShowMe();
            HideMe();
        };
        QuitBtn.OnClick += () =>
        {
            Application.Quit();
        };
        RankBtn.OnClick += () =>
        {
            RankPanel.ptr.ShowMe();
            HideMe();
        };
    }
}
