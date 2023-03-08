using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xMoveBala : MonoBehaviour
{

    public float velocidad = 5.0f;
    public float valorHerida = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movDistancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.forward * movDistancia);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            Debug.Log("he chocado con el enemigo");
            other.SendMessage("tocado", valorHerida, SendMessageOptions.DontRequireReceiver);
        }

        Destroy(this.gameObject);
    }

    
}
