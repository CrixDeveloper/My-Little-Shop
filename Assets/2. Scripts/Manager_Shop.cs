using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Shop : MonoBehaviour
{
    #region Variables to use:

    [Header("Canvas References: ")]
    public GameObject shopCanvas;
    public GameObject defaultPlayer;
    public GameObject bluePlayer;
    public GameObject greenPlayer;
    public GameObject playerHat;

    [Header("Buttons References: ")]
    public GameObject b_BuyButton;
    public GameObject b_SellButton;
    public GameObject g_BuyButton;
    public GameObject g_SellButton;
    public GameObject hat_BuyButton;
    public GameObject hat_SellButton;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Not used at the moment. 
    }

    // Update is called once per frame
    void Update()
    {
        // Not used at the moment. 
    }

    #region Methods in use:

    public void BackButton()
    {
        shopCanvas.SetActive(false);
    }

    public void PurchaseBlueShirt()
    {
        Debug.Log("Blue shirt bought! ");

        defaultPlayer.SetActive(false);
        bluePlayer.SetActive(true);
        //-----------------------------
        b_BuyButton.SetActive(false);
        b_SellButton.SetActive(true);
        //-----------------------------
        g_BuyButton.SetActive(false);
        g_SellButton.SetActive(false);
    }

    public void SellBlueShirt()
    {
        Debug.Log("Blue shirt sold! ");

        bluePlayer.SetActive(false);
        defaultPlayer.SetActive(true);
        //-----------------------------
        b_SellButton.SetActive(false);
        b_BuyButton.SetActive(true);
        //-----------------------------
        g_BuyButton.SetActive(true);
    }

    public void PurchaseGreenShirt()
    {
        Debug.Log("Green shirt bought! ");

        defaultPlayer.SetActive(false);
        greenPlayer.SetActive(true);
        //-----------------------------
        g_BuyButton.SetActive(false);
        g_SellButton.SetActive(true);
        //-----------------------------
        b_BuyButton.SetActive(false);
        b_SellButton.SetActive(false);
    }

    public void SellGreenShirt()
    {
        Debug.Log("Green shirt sold! ");

        greenPlayer.SetActive(false);
        defaultPlayer.SetActive(true);
        //-----------------------------
        g_SellButton.SetActive(false);
        g_BuyButton.SetActive(true);
        //-----------------------------
        b_BuyButton.SetActive(true);
    }

    public void PurchaseHat()
    {
        Debug.Log("Hat bought! ");

        playerHat.SetActive(true);
        //-----------------------------
        hat_BuyButton.SetActive(false);
        hat_SellButton.SetActive(true);
    }

    public void SellHat()
    {
        Debug.Log("Hat sold! ");

        playerHat.SetActive(false);
        //-----------------------------
        hat_SellButton.SetActive(false);
        hat_BuyButton.SetActive(true);
    }

    #endregion
}
