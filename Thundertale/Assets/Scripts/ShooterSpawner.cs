using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> shooterPrefabs = null;
    [Tooltip("The positive horizontal range from where the enemy can be spawned")]
    [SerializeField] Vector2 xRange = Vector2.zero;
    [Tooltip("The vertical range from where the enemy can be spawned")]
    [SerializeField] Vector2 yRange = Vector2.zero;
    [Tooltip("Interval between shooter spawn")]
    [SerializeField] Vector2 spawnInterval = Vector2.zero;
    [Tooltip("Seconds removed from the interval between enemy spawn when enemy health is critical")]
    [SerializeField] Vector2 criticalIntervalDecrease = new Vector2 (0.5f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        if (spawnInterval.x - criticalIntervalDecrease.x <= 0
            || spawnInterval.y <= criticalIntervalDecrease.y)
            print("Negative critical interval. Please recalculate.");
        StartCoroutine(SpawnShooters());
        Health.OnEnemyCritical += DecreaseSpawnInterval;
    }

    void OnDisable() => Health.OnEnemyCritical -= DecreaseSpawnInterval;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnShooters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnInterval.x, spawnInterval.y));
            if (!BattleManager.Instance.isCombatOn)
                continue;
            Vector3 spawnPoint = new Vector3(
                Random.Range(xRange.x, xRange.y),
                Random.Range(yRange.x, yRange.y));
            bool isLeft = Random.Range(0, 2) == 0;
            if (isLeft)
                spawnPoint.x *= -1;
            int shooterIndex = Random.Range(0, shooterPrefabs.Count);
            Instantiate(shooterPrefabs[shooterIndex], spawnPoint, Quaternion.identity);
        }
    }

    void DecreaseSpawnInterval() => spawnInterval -= criticalIntervalDecrease;
}
