﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    public int lives = 1;
    public GameObject player;
    public Renderer rend;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();

		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Enemy")
        {
            if (lives > 0)
            {
                StartCoroutine(Dead());
            }
            else if (lives == 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
	}

    IEnumerator Dead()
    {
        Debug.Log("Dead");
        rend.enabled = false;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        float gravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        //        yield return new WaitForSeconds(3f);
        gameObject.transform.position = new Vector2(0,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + 10);
        Debug.Log("Respawn");
        rend.enabled = true;
        yield return new WaitForSeconds(.5f);
        rend.enabled = false;
        yield return new WaitForSeconds(.5f);
        rend.enabled = true;
        yield return new WaitForSeconds(.5f);
        rend.enabled = false;
        yield return new WaitForSeconds(.5f);
        rend.enabled = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
