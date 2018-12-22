using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public float speed = 5;
    public ParticleSystem hitBullet;
    private Rigidbody2D rb;
    private AudioSource audioS = null;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        audioS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = this.transform.right * 2 * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contact = col.contacts[0];
        Quaternion rotacion = Quaternion.FromToRotation(Vector3.up, contact.normal);
        ParticleSystem hitparticleIsta =  Instantiate(hitBullet, contact.point, rotacion);
        
        Debug.Log("Choque y di play");
        audioS.Play();

        Destroy(hitparticleIsta.gameObject, 3);
        Destroy(this.gameObject, 0.3f);

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject, 0.3f);
            Destroy(col.gameObject, 0.1f);

            DataGame.Score++;
        }


    }
}
