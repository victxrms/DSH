using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsar : MonoBehaviour
{
    public Button boton;
    public Image img;
    public Sprite[] spriteNumeros;
    public Text textoNum;

    private bool contar;
    private int numero;

    // Start is called before the first frame update
    void Start()
    {
        img.gameObject.SetActive(false);
        textoNum.gameObject.SetActive(false);
        boton.onClick.AddListener(pulsado);

        contar = false;
        numero = 3;
    }

    void pulsado()
    {
        img.gameObject.SetActive(true);
        textoNum.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);

        contar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (contar)
        {

            
            switch(numero)
            {
                case 0:
                    Debug.Log("Terminado - Salto a otra escena");
                    img.gameObject.SetActive(false);
                    textoNum.gameObject.SetActive(false);
                    break;
                case 1:
                    img.sprite = spriteNumeros[0];
                    textoNum.text = "1";
                    break;
                case 2:
                    img.sprite = spriteNumeros[1];
                    textoNum.text = "2";
                    break;
                case 3:
                    img.sprite = spriteNumeros[2];
                    textoNum.text = "3";
                    break;
            }
                        
            StartCoroutine(Esperar());
            contar = false;

            numero--;

        }

        
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1) ;
        contar = true;
    }
}
