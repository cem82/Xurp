using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Transform Fp;
    public GameObject Gun;
    public float FireSpeed;
    public Rigidbody2D rb;
    public Character character;

    public GameObject Effect;
    public GameObject Effect2;
    public GameObject Juice;

    void Update()
    {
        rb.velocity = rb.GetRelativeVector(Gun.transform.right * FireSpeed);
    }         
    
    void OnTriggerEnter2D(Collider2D other)
    {
    if(other.tag == "Enemy")
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    if(other.tag == "Bounds")
        {
            SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.WallHit);
            Instantiate(Juice, transform.position, Quaternion.identity);
            Instantiate(Effect2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
