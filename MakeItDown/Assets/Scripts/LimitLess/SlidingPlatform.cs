using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{

    public bool isLeft, isRight;
    
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isLeft)
            {
                other.gameObject.GetComponent<LimitlessBallMovement>().PlatformMove(-1f);
            }
            if(isRight)
            {
                other.gameObject.GetComponent<LimitlessBallMovement>().PlatformMove(1f);
            }
        }
    }

}
