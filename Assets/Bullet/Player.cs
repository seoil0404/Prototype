using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Range(0f, 5f)]
    public float playerMoveSpeed;

    public int health = 3;

    void Start()
    {
        
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector3(horizontal, vertical, 0f).normalized * playerMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMove enemy = collision.gameObject.GetComponent<EnemyMove>();
        switch (enemy.enemyType)
        {
            case EnemyMove.EnemyType.level0:
                break;
            case EnemyMove.EnemyType.level1:
                health -= 1;
                break;
            case EnemyMove.EnemyType.level2:
                health -= 2;
                break;
            case EnemyMove.EnemyType.level3:
                health -= 3;
                break;
            default:
                break;

        }
        GameObject.Find("HealthManager").GetComponent<Health>().SetHealth(health);
        if (health <= 0) SceneManager.LoadScene("Defeat");
    }
}
