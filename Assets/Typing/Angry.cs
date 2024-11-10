using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Angry : MonoBehaviour
{
    public SpriteRenderer face;
    public TextMeshProUGUI TMP_text;

    private float speed;

    void Start()
    {
        switch(LevelController.level)
        {
            case LevelController.Level.Easy:
                speed = 0.8f;
                break;
            case LevelController.Level.Normal:
                speed = 0.65f;
                break;
            case LevelController.Level.Hard:
                speed = 0.4f;
                break;
        }
        StartCoroutine(YumraAngry());
    }

    IEnumerator YumraAngry()
    {
        yield return new WaitForSeconds(0.01f * speed * TMP_text.text.Length);
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
