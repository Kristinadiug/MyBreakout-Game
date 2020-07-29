using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HUD : EventInvoker
{
    Text ScoreText;

    Text BallsLeftText;

    int score = 0;

    int ballsLeft = 10;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        BallsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
        BallsLeftText.text = "Balls left: " + ballsLeft.ToString();

        EventManager.AddListener(EventName.PointsAddedEvent, AddPoints);
        EventManager.AddListener(EventName.BallsReduceEvent, DecreaseBallsLeft);
        EventManager.AddInvoker(EventName.GameOverEvent, this);
        EventManager.AddListener(EventName.BlockDestroyedEvent, BlockDestroyedHandler);
    }

    void AddPoints(float points = 10)
    {
        score += Convert.ToInt32(points);
        ScoreText.text = "Score: " + score.ToString();
    }

    void DecreaseBallsLeft(float cnt)
    {
        ballsLeft--;
        BallsLeftText.text = "Balls left: " + ballsLeft.ToString();

        if(ballsLeft <= 0)
        {
            ballsLeft = 10;
            InvokeEvent(EventName.GameOverEvent, score);
        }
    }

    void BlockDestroyedHandler(float a)
    {
        List<GameObject> blocks = GameObject.FindGameObjectsWithTag("Block").ToList();
        if(blocks.Count <= 1)
        {
            ballsLeft = 10;
            InvokeEvent(EventName.GameOverEvent, score);
        }
    }
}
