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

        for(int index = 0 ; index < monsters.Length; index++)
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
            int Unknownrandom = Random.Range(0, 4);
            monsters[0].GetComponent<SpriteRenderer>().sprite = sprites[Unknownrandom];
            states[0] = Unknownrandom;
        }
        
        int random = Random.Range(2, 5);
        monsters[6].GetComponent<SpriteRenderer>().sprite = sprites[random];
        states[6] = random;
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
