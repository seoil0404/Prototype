using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject[] healthObject = new GameObject[3];
    
    public void SetHealth(int health)
    {
        switch (health)
        {
            case 0:
                healthObject[0].SetActive(false);
                healthObject[1].SetActive(false);
                healthObject[2].SetActive(false);
                break;
            case 1:
                healthObject[0].SetActive(false);
                healthObject[1].SetActive(false);
                healthObject[2].SetActive(true);
                break;
            case 2:
                healthObject[0].SetActive(false);
                healthObject[1].SetActive(true);
                healthObject[2].SetActive(true);
                break;
            case 3:
                healthObject[0].SetActive(true);
                healthObject[1].SetActive(true);
                healthObject[2].SetActive(true);
                break;
            default:
                healthObject[0].SetActive(false);
                healthObject[1].SetActive(false);
                healthObject[2].SetActive(false);
                break;
        }
    }
}
