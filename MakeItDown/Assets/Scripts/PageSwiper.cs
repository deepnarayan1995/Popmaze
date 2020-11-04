using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private Vector3 panelLocation;

    public float percentThreshold = 0.2f;

    public float easing = 0.5f;

    float swipeLimit = 0f;

    void Start()
    {
        panelLocation = transform.position;
        swipeLimit = 0f;
    }

    public void OnDrag(PointerEventData pData)
    {
        //Debug.Log(pData.pressPosition - pData.position);
        float difference = pData.pressPosition.x - pData.position.x;        

        if (swipeLimit <= 0f)
        {
            if (difference <= -120f)
            {
                difference = -120f;
            }
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }
        if (swipeLimit >= 2160f)
        {
            if (difference >= 120f)
            {
                difference = 120f;
            }
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }
        else
        {
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }

    }


    public void OnEndDrag(PointerEventData pData)
    {
        //panelLocation = transform.position;
        float percentage = (pData.pressPosition.x - pData.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if(percentage > 0)
            {
                newLocation += new Vector3(-Screen.width, 0, 0);
                swipeLimit += 720;
            }
            else if(percentage < 0)
            {
                newLocation += new Vector3(Screen.width, 0, 0);
                swipeLimit -= 720;
            }
            //transform.position = newLocation;
            if(swipeLimit >= 0 && swipeLimit <= 2160)
            {
                StartCoroutine(SmoothMove(transform.position, newLocation, easing));
                panelLocation = newLocation;
            }
            else
            {
                StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
                if(swipeLimit <= 0)
                {
                    swipeLimit = 0;
                }
                else if(swipeLimit >= 2160)
                {
                    swipeLimit = 2160;
                }
            }
            
        }
        else
        {
            //transform.position = panelLocation;
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }


    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while(t <= 1f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }




}
