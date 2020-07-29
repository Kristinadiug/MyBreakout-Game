using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{

    public static void GoToMenu(MenuName name)
    {
        if(name == MenuName.Main)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if(name == MenuName.Pause)
        {
            GameObject.Instantiate(Resources.Load("PauseMenu"));
        }
        if(name == MenuName.Help)
        {
            SceneManager.LoadScene("HelpScene");
        }
    }
}
