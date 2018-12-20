using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    #region Variables
    public Base_AirplaneInput Input;
    public ParallaxBG Parallax;

    private Rigidbody2D rb2D;
    private bool isCollision = false;
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
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovemement();
	}

    #region Custom Methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollision = true;
            Debug.Log("Collision on");
        }
    }

    void HandleMovemement()
    {
        rb2D.velocity = new Vector2(0, Input.Pitch);
        Parallax.Speed = Input.StickyThrottle;
    }
    #endregion
}
