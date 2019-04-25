using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour {
    public static int lives;

    Text livesText;

    // Use this for initialization
    void Start()
    {
        livesText = GetComponent<Text>();
        lives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        //if(coins < 0)
        //coins = 0;

        livesText.text = " " + lives;
    }
    public static void AddPoints(int pointsToAdd)
    {
        lives -= pointsToAdd;
    }
}
