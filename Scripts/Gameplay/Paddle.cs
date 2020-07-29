using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    GameObject prefabIce;

    GameObject Ice;

    Rigidbody2D rb2d;

    float halfColliderWidth;
    float colliderHeight;

    bool isFrozen = false;

    Timer FreezeTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 4;
        colliderHeight = GetComponent<BoxCollider2D>().size.y;

        FreezeTimer = GetComponent<Timer>();
        FreezeTimer.AddTimerFinishedEventListener(FreezeTimerFinishedEventHandler);
        EventManager.AddInvoker(EventName.FreezerTimerChangedEvent, FreezeTimer);

        EventManager.AddListener(EventName.FreezerEvent, FreezerEffectHandler);
    }


    void FreezeTimerFinishedEventHandler()
    {
        isFrozen = false;
        Destroy(Ice);
    }

    Vector2 CalculateClampedX(Vector2 position)
    {
        Vector2 newPosition = position;
        if(position.x  - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            newPosition.x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if(position.x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            newPosition.x = ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return newPosition;
    }

    void FixedUpdate()
    {
        if(!isFrozen)
        {
            float horizontal_input = Input.GetAxis("Horizontal");
            if (horizontal_input != 0)
            {
                Vector2 position = new Vector2(transform.position.x + horizontal_input * ConfigurationUtils.PaddleMoveUnitsPerSecond, transform.position.y);
                position = CalculateClampedX(position);
                rb2d.MovePosition(position);
            }
        }
        
    }

    public void FreezerEffectHandler(float effectDuration)
    {
        isFrozen = true;
        
        
        if (!FreezeTimer.Running)
        {
            FreezeTimer.Duration = effectDuration;
            FreezeTimer.Run();

            Vector3 position = transform.position;
            position.y += 0.1f * colliderHeight;
            position.z = transform.position.z - 10;
            Ice = GameObject.Instantiate(prefabIce, position, Quaternion.identity);
        }
        else
        {
            FreezeTimer.AddSeconds(effectDuration);
        }
    }
}
