using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButtons : MonoBehaviour
{


    public void Buy500diamonds()
    {
        IAPManager.Instance.Buy500Diamonds();
    }
    public void Buy1000diamonds()
    {
        IAPManager.Instance.Buy1000Diamonds();
    }
    public void Buy5000diamonds()
    {
        IAPManager.Instance.Buy5000Diamonds();
    }
    public void BuyRemoveAds()
    {
        IAPManager.Instance.BuyNoAds();
    }


}
