using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public int coinValue;
    public int coinAmount;
    public int isLifeBought;
    public Button LifeButton;

    public void Start()
    {
        coinAmount = PlayerPrefs.GetInt("CoinAmount");
    }
    
    void Update()
    {
        isLifeBought = PlayerPrefs.GetInt("IsLifeBought");

        if(coinAmount >= 10 && isLifeBought == 0)
            LifeButton.interactable = true;
        else
            LifeButton.interactable == false;
    }

    public void buyLife()
    {
        coinAmount -= 10;
        PlayerPrefs.SetInt("IsLifeBought",1);
        Debug.Log("Life Bought!");
    }

    //Coin value and destroy coin 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag("Player"))
            print("You've collected a coin!");

        ScoreManager.AddPoints(coinValue);

        Destroy(gameObject);
    }
}
