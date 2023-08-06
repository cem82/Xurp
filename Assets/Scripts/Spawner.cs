using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
      public GameObject HYK;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float spawnTime;
    public float tbs;
    public Character character;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
;
        if(21f > timer && 20 < timer)
        {
            tbs -= 0.5f;
            timer = 0;
        }
      if(Time.time > spawnTime && Character.Begin == true)
      {
        Spawn();
        spawnTime = Time.time + tbs;
      }
    }

    void Spawn()
    {
      float randomX = Random.Range(minX, maxX);
       float randomY = Random.Range(minY, maxY);

       Instantiate(HYK, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
