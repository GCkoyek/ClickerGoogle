using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    
    public TextMeshProUGUI moneyText;

    public int money = 0;
    public float Timer = 0f;
    public float TimeChck = 10;
    public bool SaveGame = false;

    

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        moneyText.text = "$" + money.ToString();

        
    }

    void Update()
    {
        PlayerPrefs.SetInt("money", money);
        moneyText.text = "$" + money.ToString();

        Timer = Timer + 1 * Time.deltaTime;

        if (Timer >= TimeChck)
        {
            SaveGame = true;
        }

        if (SaveGame == true)
        {
            SaveGameFunc();
            LoadGameFunc();
            SaveGame = false;
            Timer = 0f;
        }

        
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void TakeMoney(int amount)
    {
        money -= amount;
        moneyText.text = "$" + money.ToString();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("money", money);
    }

    public void SaveGameFunc()
    {
        PlayerPrefs.SetInt("MoneySave", money);
    }

    public void LoadGameFunc()
    {
        money = PlayerPrefs.GetInt("MoneySave");
    }




    
}