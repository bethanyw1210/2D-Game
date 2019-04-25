using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {
    public int lifeAmount;

    //Coin value and destroy coin 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LivesCounter.AddPoints(lifeAmount);
    }
}
