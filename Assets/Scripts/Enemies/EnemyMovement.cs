using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private bool dirRight = true;
    public float speed = 5f;
    private bool flipX = false;


    //Delay between enemy starts
    int counter,randomDelay;
    private void Start()
    {
        counter = 1;
        dirRight = true;
        randomDelay = Random.Range(10,80);
        GetComponent<SpriteRenderer>().flipX = false;
    }
    void Update()
    {
        
        if(randomDelay<=counter)
        MoveDude();
        else
            counter++;
    }

    //move enemy from side to side
    private void MoveDude()
    {
        if(dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if(transform.position.x > 20f)
        {
            dirRight = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(transform.position.x <= -20f)
        {
            dirRight = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Fish")
        {
            print(other.tag);
        }
        else {
            //KillPlayer.life -= 1;
            Destroy(other.gameObject);
        print(other.tag);
        }
    }
}
