using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int coins;

    Text coinText;

	// Use this for initialization
	void Start () {
        coinText = GetComponent<Text>();
        coins = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        if(coins < 0)
            coins = 0;

        coinText.text = " " + coins;
	}
    public static void AddPoints (int pointsToAdd)
    {
        coins += pointsToAdd;
    }
}
