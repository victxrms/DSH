using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class movimiento : MonoBehaviour
{
    public Camera cam;
    public int velocidad;
    public GameObject prefabSuelo;
    public GameObject prefabValla;
    public Text texto;
    
    private Vector3 offset;
    private float ubiX;
    private float ubiZ;
    private Rigidbody rigBod;

    private float tiempo = 0;

    private Vector3 posActual;

    private System.Random rnd = new System.Random();

    private float tempNivel = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position;
       
        ubiX = 0.0f;
        ubiZ = 0.0f;

        GameObject paterPutativus = new GameObject("Objeto vacio");
        GameObject elSuelo = Instantiate(prefabSuelo, new Vector3(ubiX, 0, ubiZ), Quaternion.Euler(0f, 90f * rnd.Next(1, 2), 0f), paterPutativus.transform) as GameObject;

        rigBod = GetComponent<Rigidbody>();

        sueloInicial();
    }

    void sueloInicial()
    {


        for (int n = 0; n < 3; n++)
        {
            GameObject paterPutativus = new GameObject("Objeto vacio");
            ubiZ += 6.0f;
            GameObject elSuelo = Instantiate(prefabSuelo, new Vector3(ubiX, 0, ubiZ), Quaternion.Euler(0f, 90f * rnd.Next(1, 2), 0f), paterPutativus.transform) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            posActual = Vector3.right + Vector3.forward;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            posActual = Vector3.left + Vector3.forward;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            posActual = Vector3.back;
        }

        tiempo = velocidad * Time.deltaTime;

        rigBod.transform.Translate(posActual * tiempo);
        cam.transform.position = this.transform.position + offset;

        tempNivel += Time.deltaTime;

        texto.text = "Tiempo: " + Mathf.Round(tempNivel);

        if (tempNivel == 10f)
        {Debug.Log("tiempo superado");  tempNivel = 0; SceneManager.LoadScene("escena2.0", LoadSceneMode.Single); }


    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "suelo")
        {
            StartCoroutine(creaSuelo(other));
        }
    }

    IEnumerator creaSuelo(Collision col)
    {
        Debug.Log("cae");

        GameObject paterPutativus = new GameObject("Objeto vacio");

        GameObject obstaculo1;

        yield return new WaitForSeconds(0.5f);

        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;

        yield return new WaitForSeconds(0.5f);

        float ran = UnityEngine.Random.Range(0f, 1f);

        if (ran < 0.5f)
        {
            ubiX += 6.0f;
        }
        else ubiZ += 6.0f;

        GameObject elSuelo = Instantiate(prefabSuelo, new Vector3(ubiX, 0, ubiZ), Quaternion.Euler(0f, 90f * rnd.Next(1, 2), 0f), paterPutativus.transform) as GameObject;

        obstaculo1 = Instantiate(prefabValla, new Vector3(((UnityEngine.Random.Range(ubiX - 3, ubiX + 3 + 1))), 1, (UnityEngine.Random.Range(ubiZ - 3, ubiZ + 3 + 1))), Quaternion.Euler(0f, 90f * rnd.Next(1, 3), 0f), paterPutativus.transform) as GameObject;

        Destroy(paterPutativus, 15f) ;
    }
}
