using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Suma 3 puntos y te convierte en UFO

public class Premio_boost : MonoBehaviour
{
    GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerup.transform.position = new Vector3(powerup.transform.position.x, powerup.transform.position.y + 5, powerup.transform.position.z);
        new WaitForSeconds(0.5f);
        powerup.transform.position = new Vector3(powerup.transform.position.x, powerup.transform.position.y - 5, powerup.transform.position.z);
    }
}
