using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public int lives = 1;
    public GameObject player;
    public Renderer rend;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void OnTriggerEnnter2D (Collider2D other) {
        if (gameObject.tag == "Enemy")
        {
            if (lives > 0)
            {
                StartCoroutine(Dead());
            } 
        }
	}

    IEnumerator Dead()
    {
        Debug.Log("Dead");
        rend.enabled = false;
        yield return new WaitForSeconds(3f);
        Debug.Log("Respawn");
        rend.enabled = true;
    }
}
