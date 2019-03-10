using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour {

    private float yScale;
    private bool upOrDown;
    public float maxY=.2f;
    public float minY=.35f;
    public float speed = .001f;

	// Use this for initialization
	void Start () {
        yScale = 0.29707f;
        minY = .2f;
        maxY = .35f;
        
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
        transform.localScale= new Vector3 (0.29707f, yScale,0.29707f);
		
	}
}
