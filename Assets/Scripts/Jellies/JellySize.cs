using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySize : MonoBehaviour {

    private float yScale;
    private float xScale;
    private bool upOrDown;
    private float speed = .0015f;
    private float minY = .95f;
    private float maxY = 1.05f;
    private float minX = .95f;
    private float maxX = 1.05f;



    // Use this for initialization
    void Start()
    {
        yScale = 1f;
        minY = .95f;
        maxY = 1.05f;
        xScale = 1f;
        minX = .95f;
        maxX = 1.05f;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(upOrDown == false)
        {
            yScale += speed;
            if(yScale > maxY)
            {
                upOrDown = true;
            }
            xScale += speed;
            if(xScale > maxX)
            {
                upOrDown = true;
            }
        }
        if(upOrDown == true)
        {
            yScale -= speed;
            if(yScale < minY)
            {
                upOrDown = false;
            }
            xScale -= speed;
            if(xScale < minX)
            {
                upOrDown = false;
            }
        }
        transform.localScale = new Vector3(xScale,yScale,1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        if(collision.tag == "Kill")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    }
