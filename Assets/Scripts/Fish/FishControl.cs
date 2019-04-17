using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl:MonoBehaviour
{

    private float moveSpeed = 5;
    private int jumpHeight = 15;
    public GameObject player;
    private bool flipX = false;
    private bool grounded = true;
    public Sprite FishCharacter, turtlePowerup, gunPowerUp;
    private Rigidbody2D pcRigid;
    private float gravityStore;
    public Transform firePoint;
    public GameObject projectile;

    // Use this for initialization 
    void Start()
    {
        FishCharacter = gameObject.GetComponent<SpriteRenderer>().sprite;
        grounded = true;
        pcRigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame 
    void Update()
    {

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
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
            grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == ("Ground"))
        {
            grounded = true;
        }
        if(collision.collider.tag == ("Jellyfish"))
        {
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BubbleGun")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = gunPowerUp;
            Destroy(other.gameObject);
            StartCoroutine("BubbleGun");
        }
        //
        if(other.tag == "Turtle")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = turtlePowerup;
            Destroy(other.gameObject);
            StartCoroutine("SeaTurtle");
        }
    }

    public IEnumerator SeaTurtle()
    {
        gravityStore = pcRigid.GetComponent<Rigidbody2D>().gravityScale;
        pcRigid.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pcRigid.GetComponent<Rigidbody2D>().velocity = new Vector2(pcRigid.GetComponent<Rigidbody2D>().transform.position.x,3);
        yield return new WaitForSeconds(10f);

        pcRigid.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
    }

    /*public IEnumerator BubbleGun()
    {
        if(Input.GetKeyDown(KeyCode.E))
        Instantiate(projectile,firePoint.position,firePoint.rotation);

        projectile = Resources.Load("Assets/Prefabs/Bubble Gun Ammo.prefab") as GameObject;
       
        yield return new WaitForSeconds(20f);

        Instantiate("Assets / Prefabs / Bubble Gun Ammo.prefab");
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
    }*/
}
