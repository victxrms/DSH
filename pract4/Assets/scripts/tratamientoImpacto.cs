using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tratamientoImpacto : MonoBehaviour
{
    Image barraVida;
    float vidaRestante;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void heSidoTocado ()
    {
        Debug.Log("Me han tocao ahora desde otro metodo");
        barraVida = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        vidaRestante = GetComponent<gestorVida>().vida / GetComponent<gestorVida>().maxVida;
        barraVida.transform.localScale = new Vector3(vidaRestante, 1, 1);
    }

    public void heMuerto()
    {
        Debug.Log("He muertos");
        Destroy(this.gameObject);
    }
}
