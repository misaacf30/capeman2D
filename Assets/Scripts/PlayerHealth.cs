using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingLives;                   // should I change it?
    public static int currentLives;

    private Animator animator;
    public AudioSource liveSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //currentLives = startingLives;
        currentLives = PlayerPrefs.GetInt("lives");

        if (PlayerPrefs.HasKey("lives"))
        {
            if (PlayerPrefs.GetInt("lives") <= 0)
            {
                PlayerPrefs.SetInt("lives", 5);
                //PlayerPrefs.SetInt("highscore", 0);
            }
            currentLives = PlayerPrefs.GetInt("lives");
        }
    }


    private void Update()
    {
        PlayerPrefs.SetInt("lives", currentLives);
        if (currentLives <= 0)
            SceneManager.LoadScene("HighScores");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Live")
        {
            liveSound.Play();
            Destroy(collision.gameObject);
            currentLives++;
        }
    }
}


