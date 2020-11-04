using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject Holder1, Holder2, Holder3, Holder4;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            if(this.transform.name == "Platform1")
            {
                other.transform.SetParent(Holder1.transform);
            }
            if (this.transform.name == "Platform2")
            {
                other.transform.SetParent(Holder2.transform);
            }
            if (this.transform.name == "Platform3")
            {
                other.transform.SetParent(Holder3.transform);
            }
            if (this.transform.name == "Platform4")
            {
                other.transform.SetParent(Holder4.transform);
            }

        }
    }

}
