using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Suma 1 punto cada vez que tiene contacto

public class puntitos : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vector3.up, Time.deltaTime * velocidad);
    }

    void OnDestroy()
    {
        Vector3 posactual = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
    
}
