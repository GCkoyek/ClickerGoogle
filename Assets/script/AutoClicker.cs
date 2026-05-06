using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoClicker : MonoBehaviour
{
    public List<float> autoRoundUp = new List<float>();
    public int autoRoundUpPrice;
    public TextMeshProUGUI quantityText;
    public float Timerb = 0f;
    public float TimeChckb = 10;
    public bool SaveGame = false;

    void Update()
    {
        // Loop through each auto clicker
        for (int i = 0; i < autoRoundUp.Count; i++)
        {
            // Is it time to click?
            if (Time.time - autoRoundUp[i] >= 1.0f)
            {
                autoRoundUp[i] = Time.time;
                AnimalManager.instance.curAnimal.Damage();
            }
        }

        Timerb = Timerb + 1 * Time.deltaTime;

        if (Timerb >= TimeChckb)
        {
            SaveGame = true;
        }

        if (SaveGame == true)
        {
            SaveGameFuncb();
            LoadGameFuncb();
            SaveGame = false;
            Timerb = 0f;
        }

    }

    public void OnBuyAutoRoundUp()
    {
        if (GameManager.instance.money >= autoRoundUpPrice)
        {
            GameManager.instance.TakeMoney(autoRoundUpPrice);
            autoRoundUp.Add(Time.time);

            quantityText.text = "x " + autoRoundUp.Count.ToString();
            autoRoundUpPrice += 500;
        }
    }


    public void SaveGameFuncb()
    {
        PlayerPrefs.SetInt("autoRoundUpPrice", autoRoundUpPrice);
    }

    public void LoadGameFuncb()
    {
        autoRoundUpPrice = PlayerPrefs.GetInt("autoRoundUpPrice");
    }

}
