using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Menu : MonoBehaviour
{
    public int lvlprice;
    public int lvlnum = 0;
    

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }


   

    public void Nextlvl()
    {
        if (GameManager.instance.money >= lvlprice)
        {
            lvlnum++;
            GameManager.instance.TakeMoney(lvlprice);
            SceneManager.LoadScene("lvl2");
        }
    }

    void Update()
    {
        
    }

    

    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
