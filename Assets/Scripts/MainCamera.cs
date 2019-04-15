using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
        private float speed = .05f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            speed = speed;


            gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + speed,gameObject.transform.position.z);
        }
    }
