using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpScript : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Fish")
        {

        }
        else
            Destroy(other.gameObject);
        print(other.tag);
        }
    }
