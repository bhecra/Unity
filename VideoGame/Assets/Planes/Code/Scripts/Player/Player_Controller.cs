using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    #region Variables
    public Base_AirplaneInput input;
    public ParallaxBG Parallax;
    public GameObject bullet;
    public Transform pointBullet;
    public Collider2D colliderPlayer;
    public float smoothSpeed = 1.0f;
    public float speedPitch = 1.0f;
    public float speedHorizon = 1.0f;

    private Rigidbody2D rb2D;
    private Animator animController;
    private bool isCollision = false;
    private float wantedAngle = 30;
    #endregion


    #region Properties
    public bool IsCollision
    {
        get { return isCollision; }
        set { isCollision = value; }
    }
    #endregion

    #region Built In Methods
    #endregion
    // Use this for initialization
    void Start () {
        rb2D = this.GetComponent<Rigidbody2D>();
        animController = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovemement();

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Presionado");
            HandleShooter();
        }

        HandlePitch();


	}

    #region Custom Methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollision = true;
            Debug.Log("Collision on");
        }*/
    }

    void HandleMovemement()
    {
        rb2D.velocity = new Vector2(input.SpeedHorizontal * speedHorizon , speedPitch * input.Pitch);
        Parallax.Speed = input.Throttle;
    }

    void HandleShooter()
    {
        animController.SetTrigger("shooter");
        GameObject bulletIns = Instantiate(bullet, pointBullet.position, pointBullet.rotation);
        Physics2D.IgnoreCollision(bulletIns.transform.GetComponent<Collider2D>(), colliderPlayer);
    }

    void HandlePitch()
    {
        Vector3 finalAngle = Vector3.forward * input.Pitch * wantedAngle;
        this.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(finalAngle), Time.deltaTime * smoothSpeed);
    }
    #endregion
}
