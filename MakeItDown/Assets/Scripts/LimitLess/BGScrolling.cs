using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float scroll_speed = 0.3f;

    private MeshRenderer mRendr;

    public bool isGameOver = false;

    void Awake()
    {
        mRendr = GetComponent<MeshRenderer>();
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
        Vector2 offset = mRendr.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * Time.deltaTime * scroll_speed;

        mRendr.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }


}
