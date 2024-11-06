using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public EdgeCollider2D edge;

    public float radius;

    private const float MAX = Mathf.PI * 2;

    // Start is called before the first frame update
    void Start()
    {
        int maxIndex = edge.pointCount;
        Vector2[] points = new Vector2[maxIndex];
        int index = 0;
        for(float current = 0; current < MAX; current += MAX / (maxIndex-1))
        {
            points[index] = new Vector2(Mathf.Cos(current) * radius - transform.position.x, Mathf.Sin(current) * radius - transform.position.y);
            index++;
        }
        edge.points = points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
