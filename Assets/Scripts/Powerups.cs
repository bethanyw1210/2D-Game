using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public int coinValue;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == "Fish")
            print("You've collected a coin!");

        Destroy(gameObject);
    }
}
