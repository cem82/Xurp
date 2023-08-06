using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Shoot;
    public AudioClip Kill;
    public AudioClip Death;
    public AudioClip FirstHit;
    public AudioClip WallHit;

    public static SoundManager sm;

    void Awake()
    {
        if(sm != null && sm != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sm = this;
        DontDestroyOnLoad(this);
    }


}
