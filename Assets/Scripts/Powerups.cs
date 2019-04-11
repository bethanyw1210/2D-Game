using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public GameObject turtlePowerup;
    private float lastXPosition, lastYPosition, edgeDistance = 10f;



    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == "Turtle")
            Destroy(gameObject);
        GetComponent<SpriteRenderer>().sprite = ("TurtlePowerup");

        if(!(edgeDistance < lastXPosition) && !(-edgeDistance > lastXPosition))
        {
            GameObject turtlePowerup = Instantiate(turtlePowerup,new Vector2(lastXPosition + lastYPosition,gameObject.transform.rotation));
            lastYPosition = GameObject.Find("Fish Character").transform.position.x;
            lastYPosition = GameObject.Find("Fish Character").transform.position.y;
        }


    }
}
