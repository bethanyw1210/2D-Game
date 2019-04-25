using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl:MonoBehaviour
{

    private float moveSpeed = 5;
    private int jumpHeight = 15;
    public GameObject player;
    private bool flipX = false, canFire = true;
    private bool grounded = true;
    public Sprite FishCharacter, turtlePowerup, gunPowerUp;
    private Rigidbody2D pcRigid;
    private float gravityStore;
    public Transform firePoint;
    public GameObject projectile;
    public float projectileSpeed = 10f;
    private float counter;

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
        //move Sea Turtle up
        if(gameObject.GetComponent<SpriteRenderer>().sprite == turtlePowerup)
        {
            Moverupper();
            
        }

        //Fishie Controls
        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }

        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            gameObject.transform.localScale = new Vector3(1,1,1);
        }

        //Make fishie jump
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

        //Press W to use gun
        if(gameObject.GetComponent<SpriteRenderer>().sprite == gunPowerUp)
        {
            counter++;
            if(Input.GetKey(KeyCode.W)&&counter > 25)
            {
              
                projectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
                if(gameObject.transform.localScale.x<0)
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed,0);
                else projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed,0);

                projectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
                if(gameObject.transform.localScale.x < 0)
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed,1f);
                else projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed,1f);

                projectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
                if(gameObject.transform.localScale.x < 0)
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed,2f);
                else projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed,2f);

                projectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
                if(gameObject.transform.localScale.x < 0)
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed,-1f);
                else projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed,-1f);

                projectile = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
                if(gameObject.transform.localScale.x < 0)
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed,-2f);
                else projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed,-2f);
                //Fire();
                counter = 0;
            }
        }
    }

    //Fish can jump off of Jellies and ground
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

    //Have fish sprite cahnge to Powerup sprite
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

    //Code to make Sea Turtle work
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
        Moveup();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + .25f,0);
        pcRigid.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        Moveup();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + .25f,0);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        Moveup();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        
    }

    //makes Sea Turtle move up and enemies don't affect it
    public void Moverupper()
    {
        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.y > gameObject.transform.position.y)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + .25f,0);
        /*else if 
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y/2,0);
        */
        if(gameObject.GetComponent<Rigidbody2D>().velocity.y<0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y+1,0);
            

        }

        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x > gameObject.transform.position.x+5)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x+.5f,gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }
        else if (GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+5 < gameObject.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x -.5f,gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }
        
    }
    public void Moveup()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x,gameObject.GetComponent<Rigidbody2D>().velocity.y + 3f,0);
    }

    //Make Bubble gun shoot
    public IEnumerator BubbleGun()
    {
        //Fire();

        yield return new WaitForSeconds(18f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        Update();
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = gunPowerUp;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = gunPowerUp;
        yield return new WaitForSeconds(.5f);

        //  Instantiate("Assets / Prefabs / Bubble Gun Ammo.prefab");
        gameObject.GetComponent<SpriteRenderer>().sprite = FishCharacter;
        Update();
    }

    /*private IEnumerator Fire()
    {

        
        yield return new WaitForSeconds(1f);
        canFire = true;

    }*/
}
