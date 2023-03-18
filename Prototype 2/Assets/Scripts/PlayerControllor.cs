using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    private float speed = 10.0f;
    private float xRange = 19;
    public GameObject projectilePrefab; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FireProjectile();
    }

    private void FireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Lauch a prjectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // player boundry
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
