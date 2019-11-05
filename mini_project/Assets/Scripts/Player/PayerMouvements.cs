using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerMouvements : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 3.0f;
    public GameObject boullet;
    private float timeToFire = 0.0f;
    private float fireRate = 4.0f;
    public int playerLifePoints = 100;

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
        
        if (Input.GetKey(KeyCode.Space) && Time.time >= timeToFire) { //shoot boullet with delay
            timeToFire = Time.time + 1 / fireRate;
            Instantiate(boullet, GameObject.FindGameObjectWithTag("BoulletPosition").transform.position, GameObject.FindGameObjectWithTag("BoulletPosition").transform.rotation);
        }
    }

    void OnCollisionEnter(Collision monster) {
        if (playerLifePoints <= 0){
            Destroy(gameObject);
        }
        if (monster.gameObject.CompareTag("EasyMonster")) {
            playerLifePoints -= 2;
        }
        if (monster.gameObject.CompareTag("MiddleMonster")) {
            playerLifePoints -= 20;
        }
        if (monster.gameObject.CompareTag("StrongMonster")) {
            playerLifePoints -= 10;
        }
    }
    void OnCollisionStay(Collision monster) {
        if (playerLifePoints <= 0){
            Destroy(gameObject);
        }
        if (monster.gameObject.CompareTag("EasyMonster")) {
            playerLifePoints -= 1;
        }
        if (monster.gameObject.CompareTag("MiddleMonster")) {
            playerLifePoints -= 5;
        }
        if (monster.gameObject.CompareTag("StrongMonster")) {
            playerLifePoints -= 2;
        }
    }
}
