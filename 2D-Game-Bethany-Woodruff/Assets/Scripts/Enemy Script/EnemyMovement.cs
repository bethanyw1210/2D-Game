using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float walkSpeed = 8f;
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
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        }
        else
        {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        }

    }
}
