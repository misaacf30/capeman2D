using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    private int score;
    public static int newScore;
    public AudioSource coinSound;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("highscore"))
            score = PlayerPrefs.GetInt("highscore");
    }


    void Update()
    {      
        scoreText.text = "Score: " + score;
        livesText.text = "x" + PlayerHealth.currentLives;
        newScore = score;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            Destroy(other.gameObject);
            score = score + 1;                  // +1 for coins
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            Destroy(collision.gameObject);
            score = score + 1;                  // +1 for coins
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
