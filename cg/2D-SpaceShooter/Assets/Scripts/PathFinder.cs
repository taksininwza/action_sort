using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    int waypointIndex = 0;
    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    private void Start()
    {
        waveConfig = enemySpawner.GetCurrentWaveConfig;
        waveConfig.InitWaveConfig();
        transform.position = waveConfig.StartingWaypoint.position;
    }
    private void Update()
    {
        followPath();
    }

    private void followPath()
    {
        if (waypointIndex < waveConfig.Waypoints.Count)
        {
            Vector3 targetPosition = waveConfig.Waypoints[waypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, waveConfig.MoveSpeed);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
