using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Shop : MonoBehaviour
{
    #region Variables to use:

    // Private non-visible variables: 
    public static Manager_Shop Instance;

    [Header("Shop Item: ")]
    public Class_Item blue, green, hat;

    [Header("Canvas References: ")]
    public GameObject shopCanvas;
    public GameObject defaultPlayer;
    public GameObject bluePlayer;
    public GameObject greenPlayer;
    public GameObject playerHat;
    public Text titleText;

    [Header("Buttons References: ")]
    public GameObject b_BuyButton;
    public GameObject b_SellButton;
    public GameObject g_BuyButton;
    public GameObject g_SellButton;
    public GameObject hat_BuyButton;
    public GameObject hat_SellButton;

    #endregion

    // Awake is called before any other method
    void Awake()
    {
        Instance = this;
    }

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
        if (Data_Player.money < blue.cost)
        {
            titleText.color = Color.red;
            titleText.text = "Hey Amigo! You don't have enough plata!!";

            return;
        }
        else if (Data_Player.money >= blue.cost)
        {
            Data_Player.money -= blue.cost;

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
    }

    public void SellBlueShirt()
    {
        Data_Player.money += (blue.cost / 2);

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
        if (Data_Player.money < green.cost)
        {
            titleText.color = Color.red;
            titleText.text = "Hey Amigo! You don't have enough plata!!";

            return;
        }
        else if (Data_Player.money >= green.cost)
        {
            Data_Player.money -= green.cost;

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
    }

    public void SellGreenShirt()
    {
        Data_Player.money += (green.cost / 2);

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
        if (Data_Player.money < hat.cost)
        {
            titleText.color = Color.red;
            titleText.text = "Hey Amigo! You don't have enough plata!!";

            return;
        }
        else if (Data_Player.money >= hat.cost)
        {
            Data_Player.money -= hat.cost;

            Debug.Log("Hat bought! ");

            playerHat.SetActive(true);
            //-----------------------------
            hat_BuyButton.SetActive(false);
            hat_SellButton.SetActive(true);
        }
    }

    public void SellHat()
    {
        Data_Player.money += (hat.cost / 2);

        Debug.Log("Hat sold! ");

        playerHat.SetActive(false);
        //-----------------------------
        hat_SellButton.SetActive(false);
        hat_BuyButton.SetActive(true);
    }

    public void PurchasedSound()
    {
        Manager_Audio.Instance.PlayAudio("Purchased Clip");
    }

    #endregion
}
