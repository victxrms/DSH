using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestorVida : MonoBehaviour
{
    public float vida = 5.0f;
    public float maxVida = 10.0f;

    public UnityEvent heSidoTocado;
    public UnityEvent heMuerto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tocado(float fuerza)
    {
        heSidoTocado.Invoke();
        vida -= fuerza;
        if (vida <= 0)
        {
            heMuerto.Invoke();
        }
    }
}
