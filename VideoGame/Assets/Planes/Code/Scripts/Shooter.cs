using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float speed = 5;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
      
        rb.velocity = this.transform.right * 2 * speed;

	}

    
}
