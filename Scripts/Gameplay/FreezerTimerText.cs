using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezerTimerText : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddListener(EventName.FreezerTimerChangedEvent, EffectTimeChangedEventHandler);
    }

    void EffectTimeChangedEventHandler(float duration)
    {
        if (duration > 0)
        {
            GetComponent<Text>().text = "Freezed " + Math.Round(duration, 2);
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }
}
