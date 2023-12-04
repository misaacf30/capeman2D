using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public Transform[] resetPoints;
    public Transform f2;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Fallbreak1")
        {
            PlayerHealth.currentLives--;
            if (PlayerHealth.currentLives <= 0)
            {
                yield return new WaitForSeconds(0.05f);
                SceneManager.LoadScene("HighScores");
                yield return null;
            }
            if (resetPoints[0] != null)
                this.transform.position = resetPoints[0].transform.position;
        }
        if (collision.gameObject.name == "Hazardbreak1")
        {
            PlayerHealth.currentLives--;
            if (PlayerHealth.currentLives <= 0)
            {
                yield return new WaitForSeconds(0.05f);
                SceneManager.LoadScene("HighScores");
                yield return null;
            }
            if (resetPoints[0] != null)
                this.transform.position = resetPoints[0].transform.position;
        }
        if (collision.gameObject.name == "Fallbreak2")
        {
            PlayerHealth.currentLives--;
            if (PlayerHealth.currentLives <= 0)
            {
                yield return new WaitForSeconds(0.05f);
                SceneManager.LoadScene("HighScores");
                yield return null;
            }
            if (resetPoints[1] != null)
                this.transform.position = resetPoints[1].transform.position;
        }
        if (collision.gameObject.name == "Fallbreak3")
        {
            PlayerHealth.currentLives--;
            if (PlayerHealth.currentLives <= 0)
            {
                yield return new WaitForSeconds(0.05f);
                SceneManager.LoadScene("HighScores");
                yield return null;
            }
            if (resetPoints[2] != null)
                this.transform.position = resetPoints[2].transform.position;
        }
        if (collision.gameObject.name == "Fallbreak4")
        {
            PlayerHealth.currentLives--;
            if (PlayerHealth.currentLives <= 0)
            {
                yield return new WaitForSeconds(0.05f);
                SceneManager.LoadScene("HighScores");
                yield return null;
            }
            if (resetPoints[3] != null)
                this.transform.position = resetPoints[3].transform.position;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if (resetPoints[0] != null)
                this.transform.position = resetPoints[0].transform.position;
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            if (f2 != null)
                this.transform.position = f2.transform.position;
        }
    }
}
