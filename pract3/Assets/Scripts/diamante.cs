using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Suma 5 puntos cada vez que tiene contacto

public class Premio_salto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, Time.deltaTime * 50);
    }
}
