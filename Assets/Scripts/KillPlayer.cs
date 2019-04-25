using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    public GameObject life1, life2, life3;
    //private bool life;
    private int lives;
    public GameObject player;
    public Renderer rend;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();

        lives = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);


    }

	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Enemy")
        {
            if (lives > 0)
            {
                StartCoroutine(Dead());
                lives--;
                //Destroy(gameObject);
            }
            else if (lives == 0)
            {
                //yield return new WaitForSeconds(3f);
                SceneManager.LoadScene("MainMenu");
            }
        }

        if(other.tag == "Kill")
        {
            if(lives > 0)
            {
                StartCoroutine(Dead());
                lives--;
                //Destroy(gameObject);
            }
            else if(lives == 0)
            {
                //yield return new WaitForSeconds(3f);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    //Kill and respawn player
    IEnumerator Dead()
    {
        if(lives < 3)
            //life = 3;
        switch(lives)
        {
            case 2:
                life1.gameObject.SetActive(true);
                life1.gameObject.SetActive(true);
                life1.gameObject.SetActive(false);
                break;

            case 1:
                life1.gameObject.SetActive(true);
                life1.gameObject.SetActive(false);
                life1.gameObject.SetActive(false);
                break;

            case 0:
                life1.gameObject.SetActive(false);
                life1.gameObject.SetActive(false);
                life1.gameObject.SetActive(false);
                break;

            /*case 0:
                life1.gameObject.SetActive(false);
                life1.gameObject.SetActive(false);
                life1.gameObject.SetActive(false);
                break;*/
        }

        /*if(life = 3)
        {
            life1.gameObject.SetActive(true);
            life1.gameObject.SetActive(true);
            life1.gameObject.SetActive(true);
        }

        if(life = 2)
        {
            life1.gameObject.SetActive(false);
            life1.gameObject.SetActive(true);
            life1.gameObject.SetActive(true);
        }

        if(life = 1)
        {
            life1.gameObject.SetActive(false);
            life1.gameObject.SetActive(false);
            life1.gameObject.SetActive(true);
        }

        if(life = 0)
        {
            life1.gameObject.SetActive(false);
            life1.gameObject.SetActive(false);
            life1.gameObject.SetActive(false);
        }*/

        Debug.Log("Dead");
        rend.enabled = false;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        float gravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        //        yield return new WaitForSeconds(3f);
        gameObject.transform.position = new Vector2(0,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + 10);
        Debug.Log("Respawn");
        rend.enabled = true;
        yield return new WaitForSeconds(.5f);
        rend.enabled = false;
        yield return new WaitForSeconds(.5f);
        //gameObject.transform.position = new Vector2(0,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + 10);
        rend.enabled = true;
        yield return new WaitForSeconds(.5f);
        rend.enabled = false;
        yield return new WaitForSeconds(.5f);
        rend.enabled = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
