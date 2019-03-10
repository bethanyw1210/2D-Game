using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour {

    public float moveSpeed=3;
    public int jumpHeight = 10;
    public GameObject player;
    private bool flipX = false;
    private bool grounded = true;
	// Use this for initialization
	void Start () {
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.x);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.x);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
            grounded = false;
        }

    }
}
