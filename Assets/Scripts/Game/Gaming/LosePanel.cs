using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePanel<LosePanel>
{
    public ButtonControl btngoon;
    public ButtonControl btnback;

    // Update is called once per frame
    void Start()
    {
        btnback.OnClick += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game  Scene");
        };
        btngoon.OnClick += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Start  Scene");
        };
        HideMe();
    }
}
