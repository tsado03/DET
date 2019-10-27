using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerMouvements : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 3.0f;
    //public float xBoundary = 18.5f; //standard actual values
    //public float zBoundary = 7.4f; //standard actual values
    public GameObject boullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reads user input from WASD and the arrow key
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //Make the player look arround(directional mouvements)
        transform.Rotate(0, horizontalInput * 3, 0);
        //Make the player move
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space)) { //shoot boullet
            Instantiate(boullet, GameObject.FindGameObjectWithTag("BoulletPosition").transform.position, GameObject.FindGameObjectWithTag("BoulletPosition").transform.rotation);
        }
    }
}
