using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddListener(EventName.GameOverEvent, GameOverEventHandler);
    }

    public void GameOverEventHandler(float score)
    {
        SceneManager.LoadScene("GameOverScene");
        ScoreUtils.FinalScore = Convert.ToInt32(score);
    }
}
