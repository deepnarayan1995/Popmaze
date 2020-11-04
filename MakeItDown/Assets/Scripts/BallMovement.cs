using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ballRB;

    public float jumpspeed;

    public bool isControlActive = false;

    public bool isLeft = false;
    public bool isRight = false;


    public float new_speed = 5f;




    void Update()
    {

        if (isControlActive)
        {

            //Keyboard control
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }
            if(Input.GetKeyUp(KeyCode.A))
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
            if(isLeft == false)
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


}
