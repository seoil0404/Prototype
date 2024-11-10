using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMonster : MonoBehaviour
{
    public float spawnRadius;
    public float spawnRate;
    public GameObject player;
    public GameObject monsterPrefab;

    private void Start()
    {
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
        spawnRate += 0.5f;

        StartCoroutine(SpawnMonster());
    }
}
