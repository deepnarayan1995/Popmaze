using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    //public float speed1, speed2, speed3, speed4;
    public float Bound_Y = 10f;

    public bool isBigOne;

    

    LimitlessGameManager GM;


    void Start()
    {
        GM = FindObjectOfType<LimitlessGameManager>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += GM.limitless_Platform_speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= Bound_Y)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            other.transform.SetParent(this.gameObject.transform);
        }
    }

}
