using UnityEngine;
using UnityEngine.UI;

public class Data_Player : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables: 
    public static Data_Player Instance;
    public static int money;

    [Header("Player's Data: ")]
    public int startMoney = 500;

    [Header("Player References: ")]
    public Text playerMoneyText;

    #endregion

    // Awake is called before any other method
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;

        playerMoneyText.text = "$ " + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoneyText.text = "$ " + money.ToString();
    }

    #region Methods in use:



    #endregion
}
