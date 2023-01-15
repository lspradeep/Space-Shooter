using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private WaveConfig waveConfig;
    [SerializeField] float speed = 5f;
    private List<Transform> points;
    private int index = 0;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();

    }

    void Start()
    {
        waveConfig = enemySpawner.getWaveConfig();
        points = waveConfig.getAllPoints();
        transform.position = waveConfig.getStartPoint().position;
    }


    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (index < points.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
            if (transform.position == points[index].position)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}