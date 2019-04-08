using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private bool dirRight = true;
    public float speed = 5f;
    private bool flipX = false;

    void Update()
    {
        if(dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if(transform.position.x > 30f)
        {
            dirRight = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(transform.position.x <= -30f)
        {
            dirRight = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }

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
}
