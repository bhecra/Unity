using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_AirplaneInput : MonoBehaviour {

    #region Variables

    public Slider throtleSlider;

    protected float pitch = 0f; //Arriba y abajo
    protected float speedHorizontal = 0f;
    protected float throttle = 0f; //Acelerador
    protected float throttleSpeed = 0.1f;
    protected float stickyThrottle;
    protected float brake = 0f; //descansos

    #endregion

    #region Properties
    public float StickyThrottle
    {
        get { return stickyThrottle; }
    }
    public float Pitch
    {
        get { return pitch; }
    }
    public float Throttle
    {
        get { return throttle; }
    }

    public float SpeedHorizontal
    {
        get{ return speedHorizontal; }
        set{ speedHorizontal = value; }
    }
    #endregion


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
    }

    #region Custom Methods
    protected virtual void HandleInput() // Encargado de las entradas 
    {
        //Process Main Control Inputs
        pitch = Input.GetAxis("Vertical");
        speedHorizontal = Input.GetAxis("Horizontal");
        throttle = throtleSlider.value;
        //throttle = Input.GetAxis("Horizontal");

        if (false)
        {
            StickyThrottleControl();
        }
    }

    void StickyThrottleControl()
    {
        stickyThrottle = throttle * throttleSpeed * Time.deltaTime;
        stickyThrottle = Mathf.Clamp01(stickyThrottle);
    }

    #endregion
}
