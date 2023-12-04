using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    public GameObject player;
    public Transform resetPoint;
    public AudioSource dieSound;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Coin").GetComponent<CircleCollider2D>());

    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
            PlayerHealth.currentLives--;
            player.GetComponent<Animator>().SetTrigger("Die");
            if (!dieSound.isPlaying)
                dieSound.Play();
            Physics2D.IgnoreCollision(player.GetComponent<CapsuleCollider2D>(), GetComponent<BoxCollider2D>());
            player.GetComponent<Rigidbody2D>().mass = 100;
        }
        
        if (collision.gameObject.tag != "Coin")
        {
            yield return new WaitForSeconds(4f);
            if (PlayerHealth.currentLives <= 0)
                SceneManager.LoadScene("HighScores");
            player.GetComponent<Animator>().SetTrigger("Reset");
            Physics2D.IgnoreCollision(player.GetComponent<CapsuleCollider2D>(), GetComponent<BoxCollider2D>(), false);
            player.transform.position = resetPoint.position;
            player.GetComponent<Rigidbody2D>().mass = 1;
            yield return null;
        }

    }

}
