using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerMouvements : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 5.0f;
    public float xBoundary = 15.0f;
    public float zBoundary = 7.2f; //standard actual values
    private float zIntervalForOutOfBound;
    private float xIntervalForOutOfBound = 20.0f;
    //private Vector3 thePointWherePlayerSchouldBeTeleported;

    public GameObject boullet;

    // Start is called before the first frame update
    void Start()
    {
        //thePointWherePlayerSchouldBeTeleported = new Vector3(xIntervalForOutOfBound, 0.0f, zIntervalForOutOfBound);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBoundary) 
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -3 * zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3 * zBoundary);
        }
        if (transform.position.z > zBoundary + 10.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary + 10.0f);
        }    
        horizontalInput = Input.GetAxis("Horizontal");
        //rotate player
        transform.Rotate(0.0f, horizontalInput * 3.0f, 0.0f);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space)) { //shoot boullet
            Instantiate(boullet, GameObject.FindGameObjectWithTag("BoulletPosition").transform.position, GameObject.FindGameObjectWithTag("BoulletPosition").transform.rotation);
        }
    }
}
