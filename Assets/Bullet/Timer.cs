using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int leftSecond;
    private void Start()
    {
        leftSecond = 30;
        StartCoroutine(ReduceTime());
    }

    IEnumerator ReduceTime()
    {
        yield return new WaitForSeconds(1f);
        leftSecond--;
        GetComponent<TextMeshPro>().text =leftSecond.ToString();
        if (leftSecond > 0) StartCoroutine(ReduceTime());
        else SceneManager.LoadScene("Victory1");
    }
}
