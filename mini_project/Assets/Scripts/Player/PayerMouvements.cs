using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerMouvements : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 3.0f;
    public float xBoundary = 15.0f;
    public float zBoundary = 7.2f; //standard actual values
    private float zIntervalForOutOfBound;
    private float xIntervalForOutOfBound = 20.0f;
    //private Vector3 thePointWherePlayerSchouldBeTeleported;

    public Rigidbody body;
    public GameObject boullet;

    // Start is called before the first frame update
    void Start()
    {
        //thePointWherePlayerSchouldBeTeleported = new Vector3(xIntervalForOutOfBound, 0.0f, zIntervalForOutOfBound);
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reads user input from WASD and the arrow key
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Applies input onto the velocity of the player's rigidbody to move the player
        body.velocity = transform.forward * speed * verticalInput * Time.deltaTime;
        transform.Rotate(0, horizontalInput * 3, 0);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space)) { //shoot boullet
            Instantiate(boullet, GameObject.FindGameObjectWithTag("BoulletPosition").transform.position, GameObject.FindGameObjectWithTag("BoulletPosition").transform.rotation);
        }
    }
}
