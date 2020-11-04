using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerShieldPlatform : MonoBehaviour
{
    public AllSoundFx sound;

    public AudioClip ShieldSound;

    public AudioSource Shieldplayer;


    [HideInInspector]
    public bool isBallChild;

    [HideInInspector]
    public GameObject PlayerBall;

    void Start()
    {
        isBallChild = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerBall = other.gameObject;
            PlayerBall.transform.SetParent(this.gameObject.transform);
            isBallChild = true;
        }
    }

    public void PlayShieldOpen()
    {
        if(sound.isSoundOn)
        {
            Shieldplayer.volume = 1f;
            Shieldplayer.PlayOneShot(ShieldSound);
        }
    }

}
