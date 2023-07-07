using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Manager_Game : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables: 
    public static Manager_Game Instance;

    [Header("Shop's UI Text References: ")]
    public Text b_ShirtCostText;
    public Text g_ShirtCostText;
    public Text hat_CostText;

    #endregion

    // Awake is called before any other method
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Manager_Audio.Instance.PlayAudio("Environment Clip");

        b_ShirtCostText.text = "$ " + Manager_Shop.Instance.blue.cost.ToString();
        g_ShirtCostText.text = "$ " + Manager_Shop.Instance.green.cost.ToString();
        hat_CostText.text = "$ " + Manager_Shop.Instance.hat.cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    #region Methods in use:

    private void RestartGame()
    {
        if (Data_Player.money < 100)
        {
            SceneManager.LoadScene("BGS-Test-MainLevel");
        }
    }

    public void ButtonSound()
    {
        Manager_Audio.Instance.PlayAudio("Button Pressed");
    }

    #endregion
}
