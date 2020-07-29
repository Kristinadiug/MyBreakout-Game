using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpTimerText : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddListener(EventName.SpeedUpTimerChangedEvent, EffectTimeChangedEventHandler);
    }

    void EffectTimeChangedEventHandler(float duration)
    {
        if (duration > 0)
        {
            GetComponent<Text>().text = "Speed Up " + Math.Round(duration, 2);
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }
}
