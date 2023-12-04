using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftEdge;
    public Transform rightEdge;
    public Transform enemy;
    public Animator animator;
    public float speed;
    
    private Vector3 initScale;
    private bool facingLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if(facingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                Flip();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                Flip();
        }
        
    }

    private void Flip()
    {
        animator.SetBool("Move", false);
        facingLeft = !facingLeft;
    }

    private void MoveInDirection(int h)
    {
        animator.SetBool("Move", true);
        
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * h,
            initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * h * speed,
            enemy.position.y, enemy.position.z);

    }

}