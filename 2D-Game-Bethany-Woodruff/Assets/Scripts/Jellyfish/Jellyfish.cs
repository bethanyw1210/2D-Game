using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour {

    private float yScale;
    private bool upOrDown;
    private float speed = .002f;
    private float minY = .95f;
    private float maxY = 1.05f;

	// Use this for initialization
	void Start () {
        yScale = 1f;
        minY = .95f;
        maxY = 1.05f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(upOrDown == false)
        {
            yScale += speed;
            if(yScale > maxY)
            {
                upOrDown = true;
            }
        }
        if(upOrDown == true)
        {
            yScale -= speed;
            if(yScale < minY)
            {
                upOrDown = false;
            }
                    
         }
        transform.localScale= new Vector3 (1f, yScale, 1f);
		
	}
}
