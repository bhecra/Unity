using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCircle : MonoBehaviour {

    public float amplitudX = 1.0f;
    public float amplitudY = 1.0f;
    public float speed = 0.5f;

    private float x;
    private float y;
    private float tiempo;
    private Vector3 posActual;

    // Use this for initialization
    void Start()
    {
        posActual = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        y = (amplitudX * Mathf.Cos(tiempo * speed));
        x = (amplitudY * Mathf.Sin(tiempo * speed));
        this.transform.localPosition = new Vector3(x, y, 0);

    }
}
