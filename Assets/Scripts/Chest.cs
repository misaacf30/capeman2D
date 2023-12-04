using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public GameObject[] coins;
    private Rigidbody2D rb;
    private Collider2D col;
    public AudioSource chestSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            chestSound.Play();
            animator.SetTrigger("Open");   
            for (int i = 0; i < coins.Length; i++)
                coins[i].SetActive(true);

            rb.isKinematic = true;
            col.enabled = false;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Open");
            for (int i = 0; i < coins.Length; i++)
                coins[i].SetActive(true);

            //rb.isKinematic = true;
            col.enabled = false;
        }
    }*/
}
