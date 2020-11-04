using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBox : MonoBehaviour
{

    GameObject otherEnemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            otherEnemy = other.gameObject;
            other.gameObject.GetComponent<Animator>().SetTrigger("Disappear");
            StartCoroutine("Dead");
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(otherEnemy);
    }


}
