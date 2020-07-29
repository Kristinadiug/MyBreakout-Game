using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioName.ButtonClick);
        SceneManager.LoadScene("GamePlay");
    }

    public void HandleQuitButtonOnclickEvent()
    {
        AudioManager.Play(AudioName.ButtonClick);
        Application.Quit();
    }

    public void HandleHelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Help);
    }
}
