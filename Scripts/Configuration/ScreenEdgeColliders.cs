using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeColliders : MonoBehaviour
{
    void Start()
    {
        AddCollider();
    }

    void AddCollider()
    {
        Vector2 bottomLeft = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom);
        Vector2 topLeft = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
        Vector2 topRight = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
        Vector2 bottomRight = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom);

        // add or use existing EdgeCollider2D
        EdgeCollider2D edge = gameObject.GetComponent<EdgeCollider2D>();

        Vector2[] edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight};
        edge.points = edgePoints;
    }
}
