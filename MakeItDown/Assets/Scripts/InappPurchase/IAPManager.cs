using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour, IStoreListener
{

    public static IAPManager Instance { set; get; }
    public StarLife health;
    public MenuManager GM;
    public GameObject RemoveAdButton;


    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string Product_500_Diamonds = "500_diamonds";
    public static string Product_1000_Diamonds = "1000_diamonds";
    public static string Product_5000_Diamonds = "5000_diamonds";
    public static string Product_No_Ads = "no_ads";


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(Product_500_Diamonds, ProductType.Consumable);
        builder.AddProduct(Product_1000_Diamonds, ProductType.Consumable);
        builder.AddProduct(Product_5000_Diamonds, ProductType.Consumable);
        builder.AddProduct(Product_No_Ads, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //calling from button click in Buying panel
    public void Buy500Diamonds()
    {
        BuyProductID(Product_500_Diamonds);
    }
    public void Buy1000Diamonds()
    {
        BuyProductID(Product_1000_Diamonds);
    }
    public void Buy5000Diamonds()
    {
        BuyProductID(Product_5000_Diamonds);
    }
    public void BuyNoAds()
    {
        BuyProductID(Product_No_Ads);
    }


    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));

                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }    
    

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;

        m_StoreExtensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {

        if (String.Equals(args.purchasedProduct.definition.id, Product_500_Diamonds, StringComparison.Ordinal))
        {
            health.diamonds += 500;
            GM.SaveGameMenu();
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Product_1000_Diamonds, StringComparison.Ordinal))
        {
            health.diamonds += 1000;
            GM.SaveGameMenu();
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Product_5000_Diamonds, StringComparison.Ordinal))
        {
            health.diamonds += 5000;
            GM.SaveGameMenu();
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Product_No_Ads, StringComparison.Ordinal))
        {
            health.isAdRemoved = 1;
            health.diamonds += 250;
            RemoveAdButton.SetActive(false);
            GM.SaveGameMenu();
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }





    public Product GetProduct(string productID)
    {
        if (m_StoreController != null && m_StoreController.products != null && !string.IsNullOrEmpty(productID))
        {
            return m_StoreController.products.WithID(productID);
        }
        return null;
    }





}