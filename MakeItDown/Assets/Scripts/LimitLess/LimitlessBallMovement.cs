using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitlessBallMovement : MonoBehaviour
{
    public PlatformSpawner pSpawner;

    public Rigidbody2D ballRB;

    public float jumpspeed;

    public bool isControlActive = false;

    public bool isLeft = false;
    public bool isRight = false;


    public float new_speed = 5f;


    void Update()
    {
        //Changing Gravity scale and movement speed

        if (pSpawner.gameplayTimer > 0.5f && pSpawner.gameplayTimer <= 1f)
        {
            ballRB.gravityScale = 0.5f;
        }
        else if (pSpawner.gameplayTimer > 1f && pSpawner.gameplayTimer <= 1.6f)
        {
            ballRB.gravityScale = 0.6f;
        }
        else if (pSpawner.gameplayTimer > 1.6f && pSpawner.gameplayTimer <= 2.3f)
        {
            new_speed = 4f;
            ballRB.gravityScale = 0.7f;
        }
        else if (pSpawner.gameplayTimer > 2.3f && pSpawner.gameplayTimer <= 3.1f)
        {
            new_speed = 5f;
            ballRB.gravityScale = 0.8f;
        }
        else if (pSpawner.gameplayTimer > 3.1f && pSpawner.gameplayTimer <= 4f)
        {
            new_speed = 6f;
        }
        else if (pSpawner.gameplayTimer > 4f && pSpawner.gameplayTimer <= 5.5f)
        {
            new_speed = 6f;
        }
        else if (pSpawner.gameplayTimer > 5.5f && pSpawner.gameplayTimer <= 7.5f)
        {
            new_speed = 7f;
        }
        else if (pSpawner.gameplayTimer > 7.5f && pSpawner.gameplayTimer <= 10f)
        {
            new_speed = 8f;
        }
        else if (pSpawner.gameplayTimer > 10f && pSpawner.gameplayTimer <= 12f)
        {
            new_speed = 9f;
        }




            //Keyboard control
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                DontMoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveRight();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                DontMoveRight();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                DontJump();
            }

            //Touch control
            if (isLeft == true)
            {
                ballRB.AddForce(Vector2.left * new_speed);
            }
            if (isLeft == false)
            {
                ballRB.AddForce(Vector2.left * 0f);
            }
            if (isRight == true)
            {
                ballRB.AddForce(Vector2.right * new_speed);
            }
            if (isRight == false)
            {
                ballRB.AddForce(Vector2.right * 0f);
            }


        }






    public void DontMoveLeft()
    {
        isLeft = false;
        //ballRB.AddForce(Vector2.left * 0f);
    }
    public void DontMoveRight()
    {
        isRight = false;
        //ballRB.AddForce(Vector2.right * 0f);
    }

    public void MoveLeft()
    {
        //ballRB.AddForce(Vector2.left * speed);
        isLeft = true;
    }

    public void MoveRight()
    {
        isRight = true;
        //ballRB.AddForce(Vector2.right * speed);
    }

    public void Jump()
    {
        ballRB.AddForce(Vector2.up * jumpspeed);
    }
    public void DontJump()
    {
        ballRB.AddForce(Vector2.up * 0f);
    }



    public void PlatformMove(float x)
    {
        ballRB.velocity = new Vector2(x, ballRB.velocity.y);
    }


}
