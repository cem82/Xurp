using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public float speed = 600f;
    public float firespeed;
    float rotZ;
    bool toRight;
    public Transform firepoint;
    public GameObject Bullet;
    public Rigidbody2D rb;

    public float timer;
    public float maxTimer;

    public float overheat;
    public float maxOverheat;
    public bool canShoot = true;
    public GameObject Gun;
    public GameObject muzzleeffect;
    public Image HealthBar;

    public CooldownTimer cTimer;

    public GameObject Effect;
    public Animator transictionAnim;
    public Animator anim;
    public KillCounter kc;
    public GameObject SpaceLogo;
    public static bool Begin = false;

    void Start()
    {
       
        cTimer.MaxCooldown(maxOverheat);
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.transform.position = Gun.transform.position;
        HealthBar.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 271f);

        timer -= Time.deltaTime;

        if(overheat >= maxOverheat)
        {
            canShoot = false;
        } else
        {
            canShoot = true;
        }

            if (Input.GetKey(KeyCode.X))
        {
            if(toRight && canShoot)
            {
                rotZ -= Time.deltaTime * speed;
                overheat += Time.deltaTime;

            
            }
            if (!toRight && canShoot)
            {
                rotZ += Time.deltaTime * speed;
                overheat += Time.deltaTime;

            }
            if (timer <= 0 && canShoot)
            {
               Instantiate(Bullet, firepoint.position, firepoint.rotation);
                Instantiate(muzzleeffect, firepoint.position, firepoint.rotation);
                SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.Shoot);
                timer = maxTimer;
            } 
            
            if(canShoot)
            {
                anim.SetBool("IsShooting", true);
            } 
            if(!Begin)
            {
                Begin = true;
                KillCounter.Kills = 0;
            }
            SpaceLogo.gameObject.SetActive(false);

        } else if(overheat > 0)
        {
            overheat -= Time.deltaTime;
        }


        if(Input.GetKeyUp(KeyCode.X))
        {
            Debug.Log(Time.timeScale);
            if(toRight)
            {
                toRight = false;
            }
            else
            {
                toRight = true;
            }

            anim.SetBool("IsShooting", false);
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        cTimer.Cooldown(overheat);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            kc.Transiction = true;
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.FirstHit);
        yield return new WaitForSecondsRealtime(1f);
        SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.Death);
        HealthBar.gameObject.SetActive(false);
        Destroy(gameObject);
        Instantiate(Effect, transform.position, Quaternion.identity);
    }    
   

}
