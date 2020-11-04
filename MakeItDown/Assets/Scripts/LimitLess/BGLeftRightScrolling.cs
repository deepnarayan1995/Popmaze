using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLeftRightScrolling : MonoBehaviour
{
    public float scroll_Speed = 1f;

    private MeshRenderer mRenderer;

    public bool isGameOver = false;


    void Awake()
    {
        mRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(!isGameOver)
        {
            Scrolling();
        }
    }


    void Scrolling()
    {
        Vector2 offSet = mRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offSet.y -= Time.deltaTime * Time.deltaTime * scroll_Speed;

        mRenderer.sharedMaterial.SetTextureOffset("_MainTex", offSet);
    }
}
