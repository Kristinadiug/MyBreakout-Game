using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : EventInvoker
{
    protected int points = 10;

    virtual protected void Start()
    {
        EventManager.AddInvoker(EventName.PointsAddedEvent, this);
        EventManager.AddInvoker(EventName.BlockDestroyedEvent, this);
    }

    public void SetSize(float width, float height)
    {
        float currentWidth = GetComponent<BoxCollider2D>().size.x;
        float currentHeight = GetComponent<BoxCollider2D>().size.y;
        Vector2 newScale;
        newScale.x = width / currentWidth;
        newScale.y = height / currentHeight;

        transform.localScale = newScale;

        
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            InvokeEvent(EventName.PointsAddedEvent, points);
            Destroy(gameObject);
            InvokeEvent(EventName.BlockDestroyedEvent, 0);
            
        }
    }

    public void AddListener()
    {

    }
}
