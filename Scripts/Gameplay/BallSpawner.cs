using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    Vector2 startPosition;

    Timer timer;

    float colliderRadius;

    float minSpawnY;
    float maxSpawnY;
    float minSpawnX;
    float maxSpawnX;

    void Start()
    {
        timer = GetComponent<Timer>();
        timer.AddTimerFinishedEventListener(TimerFinishedEventHandler);
        timer.Duration = UnityEngine.Random.Range(ConfigurationUtils.MinBallSpawningTime, ConfigurationUtils.MaxBallSpawningTime);
        timer.Run();

        GameObject InitialBall = GameObject.FindGameObjectWithTag("Ball");
        startPosition = InitialBall.transform.position;
        colliderRadius = InitialBall.GetComponent<CircleCollider2D>().radius;

        minSpawnY = ScreenUtils.ScreenBottom +  (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 3;
        maxSpawnY = ScreenUtils.ScreenTop - (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 2;
        minSpawnX = ScreenUtils.ScreenLeft;
        maxSpawnX = ScreenUtils.ScreenRight;

        EventManager.AddListener(EventName.BallsReduceEvent, TrySpawnBall);

    }

    private void SpawnBall(Vector2? position = null)
    {
        Vector2 spawnPosition = position ?? startPosition;
        Instantiate(prefabBall, spawnPosition, Quaternion.identity);
    }

    private void TrySpawnBall(float t)
    {
        Vector2 position = new Vector2(0,0);
        int maxTries = 47;
        bool isCollisionFreeArea = false;
        while(maxTries > 0 && !isCollisionFreeArea)
        {
            position = new Vector2(UnityEngine.Random.Range(minSpawnX, maxSpawnX), UnityEngine.Random.Range(minSpawnY, maxSpawnY));
            Vector2 pointA = new Vector2(position.x - colliderRadius, position.y - colliderRadius);
            Vector2 pointB = new Vector2(position.x + colliderRadius, position.y + colliderRadius);
            if (Physics2D.OverlapArea(pointA, pointB))
            {
                isCollisionFreeArea = true;
            }
            maxTries--;
        }
        if(isCollisionFreeArea)
        {
            SpawnBall(position);
        }
    }

    private void TimerFinishedEventHandler()
    {
        TrySpawnBall(0);
        timer.Duration = UnityEngine.Random.Range(ConfigurationUtils.MinBallSpawningTime, ConfigurationUtils.MaxBallSpawningTime);
        timer.Run();
    }
}
