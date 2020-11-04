using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEndPoint : MonoBehaviour
{
    public GameObject Ball;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LimitlessPlatforms")
        {
            if(other.transform.GetComponentInChildren<LimitlessBallCollision>())
            {
                Ball.transform.SetParent(null);
            }
        }
    }



}
