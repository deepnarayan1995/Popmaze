using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitlessStartPoint : MonoBehaviour
{
    public AllSoundFx sound;

    public AudioClip ballAppearSound;

    public AudioSource limAudio;

    public GameObject Ball;

    public GameObject BallappearBlast;
    GameObject ballBlast;

    public LimitlessBallMovement ballmove;
    public LimitlessGameManager GM;

    Vector2 CurrentBallPos, BallSpawnPosition;

    void Start()
    {
        CurrentBallPos = Ball.transform.position;
        sound.isLimitlessBGmusicActive = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LimitlessPlatforms")
        {
            //Get the position of the ball
            BallSpawnPosition = other.transform.position;
            CurrentBallPos.x = BallSpawnPosition.x;
            Ball.transform.position = CurrentBallPos;

            //Activating the rigidbody Component of the ball
            ballmove.ballRB.gravityScale = 0f;

            //Play the blast sound
            if(sound.isSoundOn)
            {
                limAudio.volume = 1f;
                limAudio.PlayOneShot(ballAppearSound);
            }
            

            //Blast the effect
            ballBlast = Instantiate(BallappearBlast) as GameObject;
            ballBlast.transform.position = CurrentBallPos;

            //Activate the ball
            Ball.gameObject.SetActive(true);
            StartCoroutine("DestroyStartingPoint");
        }
    }

    IEnumerator DestroyStartingPoint()
    {
        yield return new WaitForSeconds(1f);
        ballmove.ballRB.gravityScale = 0.5f;
        GM.isEscapeActive = true;
        yield return new WaitForSeconds(0.1f);
        if(sound.isSoundOn)
        {
            sound.limlessBGMusic.Play();            
        }
        sound.isLimitlessBGmusicActive = true;
        Destroy(ballBlast.gameObject);
        Destroy(gameObject);        
    }


}
