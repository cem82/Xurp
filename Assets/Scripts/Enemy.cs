using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject Player;
    public GameObject Effect;


    public int Kill;
    Shake shake;

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("CamShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        RotateTowardsTarget();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Sword"|| other.tag == "Bullet")
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
            SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.Kill);
            KillCounter.Kills++;
            shake.CamShake();
            Destroy(gameObject);
            
        }
    }
    private void RotateTowardsTarget()
    {
        var offset = -90f;
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

}
