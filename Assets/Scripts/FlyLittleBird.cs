using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLittleBird : MonoBehaviour
{
    public GameManager gameManager;         //Reference to the GameManager Script
    public float velocity = 1;              //Velocity of Bird
    private Rigidbody2D rb;                 //reference for Rigidbody Component of the bird

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     //Accessing the Rigidbody Component
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            rb.velocity = Vector2.up * velocity;   //To throw object in upward direction with given velocity
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();  //Call GameOver function in GameManager Script
    }
}
