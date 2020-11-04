using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Animator FadeImage;

    void Start()
    {
        StartCoroutine("WaitForLogo");
    }

    IEnumerator WaitForLogo()
    {
        yield return new WaitForSeconds(3f);
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
