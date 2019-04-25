using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int coinValue;

    //Coin value and destroy coin 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag("Player"))
            print("You've collected a coin!");

        ScoreManager.AddPoints(coinValue);

        Destroy(gameObject);
    }
}
