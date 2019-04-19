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
    public float projectileSpeed = 10f;

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
        if(gameObject.GetComponent<SpriteRenderer>().sprite == turtlePowerup)
        {
            Moverupper();
        }

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
            if(gameObject.GetComponent<SpriteRenderer>().sprite == turtlePowerup)
                grounded = false;
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
                grounded = false;
            }
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
        gameObject.GetComponent<BoxCollider2D>().enabled=false;
        gravityStore = pcRigid.GetComponent<Rigidbody2D>().gravityScale;
        gameObject.GetComponent<Rigidbody2D>().velocity=new Vector3(0,0,0);
        //pcRigid.GetComponent<Rigidbody2D>().gravityScale = 0f;

        yield return new WaitForSeconds(8f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = turtlePowerup;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = turtlePowerup;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + .25f,0);
        pcRigid.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + .25f,0);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
    public void Moverupper()
    {
        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.y > gameObject.transform.position.y)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + .25f,0);
        else
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y-.01f,0);
        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x > gameObject.transform.position.x+5)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x+.5f,gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }
        else if (GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+5 < gameObject.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x -.5f,gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }
    }
    public IEnumerator BubbleGun()
    {
        Fire();

        yield return new WaitForSeconds(18f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = gunPowerUp;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = gunPowerUp;
        yield return new WaitForSeconds(.5f);

        //  Instantiate("Assets / Prefabs / Bubble Gun Ammo.prefab");
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
    }

    private void Fire()
    {
        if(Input.GetKey(KeyCode.W))
        {
            GameObject projectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0,projectileSpeed);
        }
    }
}
