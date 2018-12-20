using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour {

    #region Variables
    private Renderer rend;

    private float speed = 0f;
    private float time;
    #endregion

    #region properties
    public float Speed
    {
        set { speed = value; }
    }
    #endregion


    // Use this for initialization
    void Awake()
    {
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Clamp(speed, 0, 2);
        time += Time.deltaTime;
        rend.material.mainTextureOffset = new Vector2(time * speed, 0);
    }
}
