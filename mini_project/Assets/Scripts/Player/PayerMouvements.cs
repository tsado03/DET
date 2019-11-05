using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerMouvements : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject[] boullets;

    private float horizontalInput;
    private float verticalInput;
    private float timeToFire = 0.0f;
    private float fireRate = 4.0f;
    private int powerUpCount;
    private GameObject projectile;
    private PlayerHealth hp;

    // Start is called before the first frame update
    void Start()
    {
        powerUpCount = 0;
        projectile = boullets[0];
        hp = gameObject.GetComponent<PlayerHealth>();
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
        
        if (Input.GetKey(KeyCode.Space) && Time.time >= timeToFire) { //shoot boullet with delay
            timeToFire = Time.time + 1 / fireRate;
            Instantiate(projectile, GameObject.FindGameObjectWithTag("BoulletPosition").transform.position, GameObject.FindGameObjectWithTag("BoulletPosition").transform.rotation);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // wenn Player ein Medpack berührt wird er um 100 HP geheilt und das Medpack wird zerstört
        if (other.name  == "Medpack")
        {
            hp.Heal(100);
            Destroy(other.gameObject);
        }

        // wenn Player ein Powerup berührt bekommt er die nächst besseren Boullets
        if (other.name == "PowerUp")
        {
            powerUpCount++;
            if( powerUpCount < boullets.Length)
            {
                projectile = boullets[powerUpCount];
                Debug.Log("WEAPON UPGRADED: " + boullets[powerUpCount].name);
            }
            Debug.Log("Destroy: " + other.name);
            Destroy(other.gameObject);
        }

        Debug.Log("collider name: " + other.name);
    }
}
