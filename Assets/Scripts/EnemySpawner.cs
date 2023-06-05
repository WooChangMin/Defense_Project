using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(enemyPrefab, spawnPoint2.position, spawnPoint2.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
