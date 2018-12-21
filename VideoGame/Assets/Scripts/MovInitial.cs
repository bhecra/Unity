using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovInitial : MonoBehaviour {

    #region Variables
    public float speed = 1.0f;
    public float force = 1.0f;
    float h = 0.0f;
    float v = 0.0f;

    private Rigidbody2D rb = null;
    #endregion


    #region BuitIn Methods
    // Use this for initialization
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        HandleInput();
        HandleMove();

        //rb.velocity = new Vector2(h * speed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force);
        }


    }

    void HandleInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void HandleMove()
    {
        rb.velocity = new Vector2(2 * speed, v * speed);
    }

    void HanldeShoot()
    {

    }
    #endregion


}
