using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleBackButtonOnClickEvent()
    {
        AudioManager.Play(AudioName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
