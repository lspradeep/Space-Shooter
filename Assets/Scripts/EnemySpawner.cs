using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private WaveConfig currentWave;
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool isLooping = true;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfig getWaveConfig()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        while (isLooping)
        {
            for (int k = 0; k < waveConfigs.Count; k++)
            {
                currentWave = waveConfigs[k];
                for (int i = 0; i < currentWave.getEnemiesCount(); i++)
                {
                    Instantiate(currentWave.getEnemiesAt(i), currentWave.getStartPoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSecondsRealtime(0.5f);
                }
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }

    }
}
