using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumberScaleTween : MonoBehaviour
{

    Vector3 preSize, finalSize;
    
    void Start()
    {
        preSize.x = 1f;
        preSize.y = 1.1f;
        preSize.z = 1f;


        finalSize.x = 0.9f;
        finalSize.y = 1f;
        finalSize.z = 1f;

        StartCoroutine("LoadText");
    }
    IEnumerator LoadText()
    {
        LeanTween.scale(gameObject, preSize, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.scale(gameObject, finalSize, 0.1f);
    }

}
