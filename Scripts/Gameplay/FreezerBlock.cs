using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreezerBlock : Block
{
    float effectDuration = ConfigurationUtils.PickUpEffectDuration;

    protected override void Start()
    {
        EventManager.AddInvoker(EventName.FreezerEvent, this);
        base.Start();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        unityEvents[EventName.FreezerEvent].Invoke(effectDuration);
        //AudioManager.Play(AudioName.Freeze);
        base.OnCollisionEnter2D(collision);
    }

}
