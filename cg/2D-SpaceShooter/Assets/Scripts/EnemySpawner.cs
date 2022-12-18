using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigList = new List<WaveConfigSO>();
    [SerializeField] float timeBetweenWave = 1.5f;
    [SerializeField] bool isLoopin = true;
    WaveConfigSO currentWaveConfig;

    public WaveConfigSO GetCurrentWaveConfig
    {
        get { return this.currentWaveConfig; }
    }
    private void Start()
    {
        StartCoroutine(spawnEnemies());
    }
    IEnumerator spawnEnemies()
    {
    Loop:
        foreach (WaveConfigSO waveConfig in waveConfigList)
        {
            currentWaveConfig = waveConfig;

            for (int i = 0; i < currentWaveConfig.enemyCount; i++)
            {
                Instantiate(currentWaveConfig.GetEnemyPrefab(i), currentWaveConfig.StartingWaypoint.position, Quaternion.identity, this.transform);
                yield return new WaitForSeconds(currentWaveConfig.SpawnTime);
            }
            yield return new WaitForSeconds(timeBetweenWave);
        }
        if (isLoopin) goto Loop;
    }
}
