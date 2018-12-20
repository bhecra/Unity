using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_AirplaneInput : MonoBehaviour {

    #region Variables

    protected float pitch = 0f; //Arriba y abajo
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
        throttle = Input.GetAxis("Horizontal");

        if (true)
        {
            StickyThrottleControl();
        }
    }

    void StickyThrottleControl()
    {
        stickyThrottle += throttle * throttleSpeed * Time.deltaTime;
        stickyThrottle = Mathf.Clamp01(stickyThrottle);
    }

    #endregion
}
