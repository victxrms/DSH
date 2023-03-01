using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billbala: MonoBehaviour
{
    private float x;
    float current_y;
    float z;
    float min_y;
    float max_y;
    float subeobaja = 1f;

    
    
    // Start is called before the first frame update
    void Start()
    {
    x= transform.position.x;
    current_y = transform.position.y;
    z = transform.position.z;
    min_y = transform.position.y;
    max_y = transform.position.y + 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_y >= max_y)
        {
            subeobaja = 2;
        }
        else if (current_y <= min_y)
        {
            subeobaja = 1;
        }
        if(subeobaja == 1)
        {
            current_y+=0.005f;
            transform.position = new Vector3(x, current_y, z);
        }
        else
        {
            current_y-=0.005f;
            transform.position = new Vector3(x, current_y, z);
        }
    }
}
