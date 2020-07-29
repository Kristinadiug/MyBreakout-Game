using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : EventInvoker
{
    Timer LifeTimer;
    Timer WaitTimer;
    Timer EffectTimer;

    const float waitTillStartMoving = 1f;

    float increaseSpeed = 1.5f;

    bool wasMoving = false;

    float standartSpeed = 10;


     // Start is called before the first frame update
    void Start()
    {
        WaitTimer = gameObject.AddComponent<Timer>();
        WaitTimer.AddTimerFinishedEventListener(WaitTimerFinishedEventHandler);
        WaitTimer.Duration = waitTillStartMoving;
        WaitTimer.Run();

        LifeTimer = gameObject.AddComponent<Timer>();
        LifeTimer.AddTimerFinishedEventListener(LifeTimerFinishedEventHandler);

        EffectTimer = gameObject.AddComponent<Timer>();
        EffectTimer.AddTimerFinishedEventListener(EffectTimerFinishedEventHandler);
        EventManager.AddInvoker(EventName.SpeedUpTimerChangedEvent, EffectTimer);

        EventManager.AddListener(EventName.SpeedUpEvent, SpeedUp);

        EventManager.AddInvoker(EventName.BallsReduceEvent, this);
    }

    private void WaitTimerFinishedEventHandler()
    {
        StartMoving();
        wasMoving = true;

        LifeTimer.Duration = ConfigurationUtils.BallLifeTimeDuration;
        LifeTimer.Run();
    }

    private void LifeTimerFinishedEventHandler()
    {
        DeleteBall();
    }

    private void EffectTimerFinishedEventHandler()
    {
        if(wasMoving)
        {
            GetComponent<Rigidbody2D>().velocity /= increaseSpeed;
        }
    }

    void StartMoving()
    {
        const float minAngle = 30;
        const float maxAngle = 150;

        float angle = UnityEngine.Random.Range(minAngle, maxAngle);
        Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        Vector2 force = direction * ConfigurationUtils.BallImpulseForce;
        if(!EffectTimer.Finished)
        {
            force *= increaseSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }


    private void KeepSpeed()
    {
        float currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;

        if(currentSpeed < standartSpeed)
        {
            float k = standartSpeed / currentSpeed;
            GetComponent<Rigidbody2D>().velocity *= k;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(wasMoving)
        {
            KeepSpeed();
        }
              
    }

    private void DeleteBall()
    {
        InvokeEvent(EventName.BallsReduceEvent, 1);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        DeleteBall();
    }

    public void SpeedUp(float duration)
    {
        if(EffectTimer.Running)
        {
            EffectTimer.AddSeconds(duration);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity *= increaseSpeed;

            EffectTimer.Duration = duration;
            EffectTimer.Run();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioName.BallHit);
    }
}
