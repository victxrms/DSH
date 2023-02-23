using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Camera cam;
    public int velocidad;
    public GameObject prefabSuelo;

    private Vector3 offset;
    private float ubiX;
    private float ubiZ;
    private Rigidbody rigBod;

    private float tiempo = 0;

    private Vector3 posActual;

    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position;
       
        ubiX = 0.0f;
        ubiZ = 0.0f;

        rigBod = GetComponent<Rigidbody>();

        sueloInicial();
    }

    void sueloInicial()
    {
        for (int n = 0; n < 3; n++)
        {
            ubiZ += 6.0f;
            GameObject elSuelo = Instantiate(prefabSuelo, new Vector3(ubiX, 0, ubiZ), Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (posActual == Vector3.forward)
            {
                posActual = Vector3.right;
            }
            else
            {
                posActual = Vector3.forward;
            }
        }

        tiempo = velocidad * Time.deltaTime;

        rigBod.transform.Translate(posActual * tiempo);
        cam.transform.position = this.transform.position + offset;
        
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

        yield return new WaitForSeconds(0.5f);

        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;

        yield return new WaitForSeconds(0.5f);
        //Destroy(col.gameObject);

        float ran = UnityEngine.Random.Range(0f, 1f);

        if (ran < 0.5f)
        {
            ubiX += 6.0f;
        }
        else ubiZ += 6.0f;

        GameObject elSuelo = Instantiate(prefabSuelo, new Vector3(ubiX, 0, ubiZ), Quaternion.identity) as GameObject;

    }
}
