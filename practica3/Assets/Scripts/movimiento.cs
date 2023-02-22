using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position;
        rigBod = GetComponent<>

        ubiX = 0.0f;
        ubiZ = 0.0f;

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
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movHorizontal, 0.0f, movVertical);
        rb.AddForce(movimiento * velocidad);
        cam.transform.position = this.transform.position + offset;
    }
}
