using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public int coinValue;

    //Coin value and destroy coin 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag("Fish"))
            print("You've collected a coin!");

        ScoreManager.AddPoints(coinValue);

        Destroy(gameObject);
    }
}
