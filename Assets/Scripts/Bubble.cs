using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    public float speed;
    public float timeOut = 4f;

	// Use this for initialization
	void Start () {
    

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
