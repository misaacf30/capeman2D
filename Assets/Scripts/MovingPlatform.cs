using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform leftEdge;
    public Transform rightEdge;
    public Transform platform;
    public float speed;
    private bool movingLeft;

    public bool startRight = true;

    private void Update()
    {
        if (startRight)
        {
            if (movingLeft)
            {
                if (platform.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                    ChangeDirection();
            }
            else
            {
                if (platform.position.x <= rightEdge.position.x)
                    MoveInDirection(1);
                else
                    ChangeDirection();
            }
        }
        else
        {
            if (!movingLeft)
            {
                if (platform.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                    ChangeDirection();
            }
            else
            {
                if (platform.position.x <= rightEdge.position.x)
                    MoveInDirection(1);
                else
                    ChangeDirection();
            }
        }           
    }

    private void ChangeDirection()
    {
        movingLeft = !movingLeft;
    }


    private void MoveInDirection(int h)
    {
        platform.position = new Vector3(platform.position.x + Time.deltaTime * h * speed,
            platform.position.y, platform.position.z);
    }


    

}
