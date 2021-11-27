using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    //public GameControl gameController;
    public GameObject bulletPrefab;
    public float reloadTime = 0.5f; // Player can fire a bullet every half second 
    private float elapsedTime = 0;
    // public KeyCode moveLeft;
    //public KeyCode moveRight;

    // Update is called once per frame
    void Update()
    {
        /*
            float horizontal = Input.GetAxisRaw("Horizontal");
            Vector3 direction = new Vector3(horizontal, 0, 0);
            gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed); */

        elapsedTime += Time.deltaTime; // Keeping track of time for bullet firing 
                                       // Move the player left and right 
        float xMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float xPosition = Mathf.Clamp(xMovement, -7f, 7f); // Keep ship on screen 
        transform.Translate(xPosition, 0f, 0f);
        // Spacebar fires. The default InputManager settings call this "Jump" 
        // Only happens if enough time has elapsed since last firing. 
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            // Instantiate the bullet 1.2 units in front of the player 
            // and in the foreground at z=-5 
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0, 1.2f, 0);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            elapsedTime = 0f; // Reset bullet firing timer 



        }
    }
}
