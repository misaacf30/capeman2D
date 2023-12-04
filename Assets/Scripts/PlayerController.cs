using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float maxSpeed = 5;
    public float moveForce = 500f;
    public float jumpForce = 700f;

    private bool facingRight = true;
    private bool jump = false;

    public bool grounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public AudioSource jumpSound;
    public AudioSource moveSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void FixedUpdate()
    {
        Move();
        Jump();        
    }

    void Move()
    {
        //transform.rotation = Quaternion.identity;   // **

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        animator.SetBool("Grounded", grounded);

        float h = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(h));  

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        if (h == 0)
            animator.SetBool("Iddle", true);
        if (h != 0)
            animator.SetBool("Iddle", false);
        if(Mathf.Abs(h) > 0 && grounded)
        {
            if (!moveSound.isPlaying)
                moveSound.Play();
        }
        else
        {
            if (moveSound.isPlaying)
                moveSound.Stop();
        }

            
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Jump()
    {
        if (jump && grounded)
        {
            if (!jumpSound.isPlaying)
                jumpSound.Play();
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.transform.parent = collision.transform; 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
