using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kann aktuell nur nach vorne schießen
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }

    
    // Methoden die eine movement / schießen in alle Richutungen realisieren
    void moveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void moveBackwards()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    void moveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void moveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

}
