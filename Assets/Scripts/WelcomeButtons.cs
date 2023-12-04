﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeButtons : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("highscore"))
            PlayerPrefs.SetInt("highscore", 0);

        if (PlayerPrefs.HasKey("lives"))
            PlayerPrefs.SetInt("lives", 5);
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void highScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void resetScores()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("lives", 5);
        PlayerPrefs.SetInt("highscore", 0);
    }
}
