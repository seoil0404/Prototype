using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] monsters = new GameObject[7];
    public int[] states = new int[7];
    public Sprite[] sprites = new Sprite[5];
    public int leftSecond;
    public TextMeshProUGUI time;
    public TextMeshProUGUI leftObject;
    public int leftNumber;

    void Start()
    {
        switch (LevelController.level)
        {
            case LevelController.Level.Easy:
                leftNumber = 20; break;
            case LevelController.Level.Normal:
                leftNumber = 40; break;
            case LevelController.Level.Hard:
                leftNumber = 50; break;
        }

        leftObject.text = leftNumber.ToString();

        for (int index = 0 ; index < monsters.Length; index++)
        {
            states[index] = 0;
        }
        for(int index = 0; index < monsters.Length; index++)
        {
            UpdateMonster();
        }

        StartCoroutine(ReduceTime());
    }

    public void UpdateMonster()
    {
        for(int index = 1; index < monsters.Length; index++)
        {
            monsters[index-1].GetComponent<SpriteRenderer>().sprite = monsters[index].GetComponent<SpriteRenderer>().sprite;
            states[index - 1] = states[index];
        }
        if (states[0] == 4)
        {
            int Unknownrandom = BadRandom();
            monsters[0].GetComponent<SpriteRenderer>().sprite = sprites[Unknownrandom];
            states[0] = Unknownrandom;
        }

        int random = JustRandom();

        monsters[6].GetComponent<SpriteRenderer>().sprite = sprites[random];
        states[6] = random;
    }

    public int JustRandom()
    {
        float rand = Random.Range(0, 10);

        if(rand < 3)
        {
            return 4;
        }
        else
        {
            int boolRand = Random.Range(0, 2);

            if (boolRand < 1)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }

    public int BadRandom()
    {
        int rand = Random.Range(0, 3);

        if(rand == 0)
        {
            rand = Random.Range(0, 2);

            if(rand == 0)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        else
        {
            rand = Random.Range(0, 2);

            if(rand == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public void Clicked(int dir)
    {
        if(dir == 0)
        {
            if (states[0] != 2)
            {
                SceneManager.LoadScene("Defeat");
            }
        }
        else if(dir == 1)
        {
            if (states[0] != 3)
            {
                SceneManager.LoadScene("Defeat");
            }
        }
        else if(dir == 2)
        {
            if (states[0] == 2 || states[0] == 3)
            {
                SceneManager.LoadScene("Defeat");
            }
        }
        ReduceScore();
        UpdateMonster();
    }

    IEnumerator ReduceTime()
    {
        yield return new WaitForSeconds(1f);
        leftSecond--;
        time.text = leftSecond.ToString();
        if (leftSecond > 0) StartCoroutine(ReduceTime());
        else SceneManager.LoadScene("Defeat");
    }

    void ReduceScore()
    {
        leftNumber--;
        leftObject.text = leftNumber.ToString();
        if (leftNumber == 0) SceneManager.LoadScene("Victory2");
    }
}
