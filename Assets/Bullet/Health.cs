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
                Destroy(healthObject[0]);
                Destroy(healthObject[1]);
                Destroy(healthObject[2]);
                break;
            case 1:
                Destroy(healthObject[1]);
                Destroy(healthObject[2]);
                break;
            case 2:
                Destroy(healthObject[2]);
                break;
            case 3:
                break;
            default:
                Destroy(healthObject[0]);
                Destroy(healthObject[1]);
                Destroy(healthObject[2]);
                break;
        }
    }
}
