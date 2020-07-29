using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void MenuButtonHandler()
    {
        AudioManager.Play(AudioName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void PlayAgainButtonHandler()
    {
        AudioManager.Play(AudioName.ButtonClick);
        SceneManager.LoadScene("GamePlay");
    }

}
