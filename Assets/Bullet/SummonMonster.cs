using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMonster : MonoBehaviour
{
    public float spawnRadius;
    public float spawnRate;
    public GameObject player;
    public GameObject monsterPrefab;

    private float increaseSpeed;

    private void Start()
    {
        switch (LevelController.level)
        { 
            case LevelController.Level.Easy:
                increaseSpeed = 0.02f;
                break;
            case LevelController.Level.Normal:
                increaseSpeed = 0.035f;
                break;
            case LevelController.Level.Hard:
                increaseSpeed = 0.05f;
                break;
        }

        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(spawnRate*2);
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        float angle = Random.Range(0, Mathf.PI*2);

        GameObject current = Instantiate(monsterPrefab);
        current.transform.position = new Vector3(Mathf.Cos(angle) * spawnRadius, Mathf.Sin(angle) * spawnRadius, -5);

        yield return new WaitForSeconds(1/spawnRate);
        spawnRate += increaseSpeed;

        StartCoroutine(SpawnMonster());
    }
}
