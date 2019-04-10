using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerup : MonoBehaviour {

    public int coinValue;
    public int bubbleGun;
    public int turtle;
    public int school;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Fish")
            print("You've collected a coin!");

        ScoreManager.AddPoints(coinValue);

        Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Fish")
            print("You've collected the Sea Turtle Powerup!");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
