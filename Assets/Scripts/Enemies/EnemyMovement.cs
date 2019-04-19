using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private bool dirRight = true;
    public float speed = 5f;
    private bool flipX = false;

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

        /*[SerializeField] float swimSpeed = 8f;
        public bool moveRight;
        public Transform wallCheck;
        public float wallCheckRadius;
        public LayerMask whatIsWall;
        private bool hittingWall;
        private bool notAtEdge;
        public Transform edgeCheck;
        // Update is called once per frame
        void Update () {
            notAtEdge = Physics2D.OverlapCircle(edgeCheck.position,wallCheckRadius,whatIsWall);
            hittingWall = Physics2D.OverlapCircle(wallCheck.position,wallCheckRadius,whatIsWall);
            if(hittingWall || !notAtEdge)
            {
                moveRight = !moveRight;
            }
            if(moveRight)
            {
            transform.Translate(Vector2.right * swimSpeed * Time.deltaTime);
            }
            else
            {
            transform.Translate(Vector2.left * swimSpeed * Time.deltaTime);
            }
        }*/
    }
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
   
}
