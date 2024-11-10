using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    public void SetLevel(string level)
    {
        switch (level)
        {
            case "Easy":
                LevelController.level = LevelController.Level.Easy; break;
            case "Normal":
                LevelController.level = LevelController.Level.Normal; break;
            case "Hard":
                LevelController.level = LevelController.Level.Hard; break;
            default:
                Debug.Log("What the fuck did you put in??");
                break;
        }
    }
}
