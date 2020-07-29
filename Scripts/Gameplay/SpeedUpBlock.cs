using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedUpBlock : Block
{
    float effectDuration = ConfigurationUtils.PickUpEffectDuration;

    protected override void Start()
    {
        EventManager.AddInvoker(EventName.SpeedUpEvent, this);
        base.Start();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        unityEvents[EventName.SpeedUpEvent].Invoke(effectDuration);
        //AudioManager.Play(AudioName.Speed);
        base.OnCollisionEnter2D(collision);
    }
}
