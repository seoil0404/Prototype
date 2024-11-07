using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Angry : MonoBehaviour
{
    public SpriteRenderer face;
    void Start()
    {
        StartCoroutine(YumraAngry());
    }

    IEnumerator YumraAngry()
    {
        yield return new WaitForSeconds(0.05f);
        Color color = face.color;
        if(color.g > 0 && color.b > 0)
        {
            color.g -= 0.01f;
            color.b -= 0.01f;
            face.color = color;
            StartCoroutine(YumraAngry());
        }
        else
        {
            SceneManager.LoadScene("Defeat");
        }
    }
}
