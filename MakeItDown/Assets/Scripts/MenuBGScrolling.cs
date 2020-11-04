using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGScrolling : MonoBehaviour
{
    public float scroll_speed;

    private MeshRenderer mRender;

    void Awake()
    {
        mRender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scrolling();
    }


    void Scrolling()
    {
        Vector2 offset = mRender.sharedMaterial.GetTextureOffset("_MainTex");
        offset.x += Time.deltaTime * Time.deltaTime * scroll_speed;
        mRender.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}
