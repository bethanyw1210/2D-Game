﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    private int lives = 3;
    public GameObject player;
    public Renderer rend;

    public GameObject life1, life2, life3;

    // Use this for initialization
    void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();


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
                SceneManager.LoadScene("GameOver");
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
                SceneManager.LoadScene("GameOver");
            }
        }
        print(lives);
            switch(lives)
            {
                case 3:
                    life1.gameObject.SetActive(true);
                    life2.gameObject.SetActive(true);
                    life3.gameObject.SetActive(true);
                    break;

                case 2:
                    life1.gameObject.SetActive(true);
                    life2.gameObject.SetActive(true);
                    life3.gameObject.SetActive(false);
                    break;

                case 1:
                    life1.gameObject.SetActive(true);
                    life2.gameObject.SetActive(false);
                    life3.gameObject.SetActive(false);
                    break;

                case 0:
                    life1.gameObject.SetActive(false);
                    life2.gameObject.SetActive(false);
                    life3.gameObject.SetActive(false);
                    break;


            }

    }

    //Kill and respawn player
    IEnumerator Dead()
    {
        if(lives < 3)
            //lives = 3;
            
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
