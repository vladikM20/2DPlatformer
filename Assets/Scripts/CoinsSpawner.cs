using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _template;
    [SerializeField] private float _interval;

    private void Start()
    {
        StartCoroutine(SpawnCoin(_interval));
    }

    private IEnumerator SpawnCoin(float interval)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(interval);

        while (true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_template, _spawnPoints[i].position, Quaternion.identity);

                yield return waitForSeconds;
            }
        }
    }
}
