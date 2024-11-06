using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Sprite[] sprite;
    public EnemyType enemyType;

    bool isEnd = false;
    public enum EnemyType
    {
        level0, level1, level2, level3
    }

    void Start()
    {
        int index = Random.Range(0, sprite.Length);
        enemyType = (EnemyType)index;
        GetComponent<SpriteRenderer>().sprite = sprite[index];
        
        if(enemyType == EnemyType.level3)
        {
            StartCoroutine(Miracle());
        }

        Vector3 toPos = GameObject.Find("Player").transform.position - transform.position;
        
        toPos = toPos.normalized;

        GetComponent<Rigidbody2D>().velocity = toPos * 3;

        Destroy(gameObject, 7f);
    }

    IEnumerator Miracle()
    {
        yield return new WaitForSeconds(2f);
        int index = Random.Range(0, 2);
        if(index == 0)
        {
            enemyType = EnemyType.level0;
            GetComponent<SpriteRenderer>().sprite = sprite[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnd == false) isEnd = true;
        else if (isEnd == true) Destroy(gameObject);
    }
}
