using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Suma 3 puntos y te convierte en UFO

public class Premio_boost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.y +=5;
        waitforseconds(0,5);
        transform.position.y -=5;        
    }
}
