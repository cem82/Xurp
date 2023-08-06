using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillCounter : MonoBehaviour
{
    public static int Kills;
    public Text text;
    public Animator transictionAnim;
    public GameObject Effect;
    public bool Transiction = false;
    public Character character;


        // Update is called once per frame
        void Update()
    {
        text.text = Kills.ToString();

        if(Transiction)
        {
            StartCoroutine("DeathScreen");
        }
    }

    IEnumerator DeathScreen()
    {

        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1f);
        transictionAnim.SetTrigger("IsDead");
        yield return new WaitForSeconds(1f);
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(0);
        Character.Begin = false;
        character.SpaceLogo.gameObject.SetActive(true);
        
    }
}
