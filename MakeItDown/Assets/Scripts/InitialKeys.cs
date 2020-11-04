using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialKeys : MonoBehaviour
{
    public AllSoundFx sound;

    public Animator AssociatedGateAnim;

    public GameObject KeyBlast;
    GameObject keyFX;

    public ParticleSystem SmallGatefx;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            sound.PlayKeyFound();
            Vector3 pos = this.transform.position;
            keyFX = Instantiate(KeyBlast) as GameObject;
            keyFX.transform.position = new Vector3(pos.x, pos.y, -5f);
            AssociatedGateAnim.SetTrigger("Open");
            SmallGatefx.Play();
            Destroy(this.gameObject);

        }
    }

}
