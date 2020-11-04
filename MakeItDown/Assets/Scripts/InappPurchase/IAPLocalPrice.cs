using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IAPLocalPrice : MonoBehaviour
{

    [HideInInspector]
    public string productID;

    public TextMeshProUGUI PriceText;
    public bool isNoAds, is500D, is1000D, is5000D;


    [System.Runtime.InteropServices.DllImport("KERNEL32.DLL")]
    private static extern int GetUserDefaultLCID();
    

    void OnEnable()
    {
        if (isNoAds)
        {
            productID = "no_ads";
        }
        else if (is500D)
        {
            productID = "500_diamonds";
        }
        else if (is1000D)
        {
            productID = "1000_diamonds";
        }
        else if (is5000D)
        {
            productID = "5000_diamonds";
        }


        UpdateText();
    }


    private void UpdateText()
    {
        var product = IAPManager.Instance.GetProduct(productID);

        if (product != null)
        {
            System.Globalization.CultureInfo culture =
                GetCultureInfoFromISOCurrencyCode(product.metadata.isoCurrencyCode);            

            if (culture != null)
            {
                PriceText.text = product.metadata.localizedPrice.ToString("C", culture);
            }
            else
            {
                PriceText.text = product.metadata.localizedPriceString;
            }
                     
        }
    }
    public static System.Globalization.CultureInfo GetCultureInfoFromISOCurrencyCode(string code)
    {
        foreach (System.Globalization.CultureInfo ci
            in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures))
        {
            System.Globalization.RegionInfo ri = new System.Globalization.RegionInfo(ci.LCID);
            if (ri.ISOCurrencySymbol == code)
                return ci;
        }
        return null;
    }



    //public Product GetUnityPurchasingProduct(string productId)
    //{
    //    // If purchasing is not initialized yet, just return a null product
    //    if (!CodelessIAPStoreListener.initializationComplete)
    //    {
    //        return null;
    //    }
    //    Product[] products = CodelessIAPStoreListener.Instance.StoreController.products.all;
    //    foreach (Product product in products)
    //    {
    //        if (string.Compare(product.definition.id, productId) == 0)
    //        {
    //            return product;
    //        }
    //    }
    //    return null;
    //}




}



//CultureInfo culture = CultureInfo.GetCultureInfo(GetUserDefaultLCID());



//if(PriceText != null)
//{
//    PriceText.text = product.metadata.localizedPriceString;
//}   

