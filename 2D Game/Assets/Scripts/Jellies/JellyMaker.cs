using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMaker:MonoBehaviour
{

    public class JellyfishMaker:MonoBehaviour
    {
        private float minDistance = 1, maxDistance = 10, lastXPosition, lastYPosition, lastXPosition2, lastYPosition2, edgeDistance = 10f, maxHeight = 30;
        private int jellyfishCount, whichjellyfish;
        public int level;
        public GameObject jellyfish1, jellyfish2, jellyfish3, jellyfishToMake;

        // Use this for initialization
        void Start()
        {
            level = 1;
            lastYPosition = -15f;
            BringOnTheJellies();
        }

        // Update is called once per frame
        void Update()
        {
            if(gameObject.transform.position.y - 10 < GameObject.FindGameObjectWithTag("MainCamera").transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + 30,gameObject.transform.position.z);
                maxHeight = 40 + GameObject.FindGameObjectWithTag("MainCamera").transform.position.y;
                BringOnTheJellies();
                level++;



            }
        }
        public void BringOnTheJellies()
        {
            do
            {
                whichjellyfish = Random.Range(1,4);
                switch(whichjellyfish)
                {
                    case 1:
                        jellyfishToMake = jellyfish1;
                        break;
                    case 2:
                        jellyfishToMake = jellyfish2;
                        break;
                    case 3:
                        jellyfishToMake = jellyfish3;
                        break;
                }

                if(!(edgeDistance < lastXPosition) && !(-edgeDistance > lastXPosition))
                {
                    GameObject newJellyfish = Instantiate(jellyfishToMake,new Vector2(lastXPosition + Random.Range(0f,8f),lastYPosition + Random.Range(3f,5f)),gameObject.transform.rotation);
                    lastXPosition = newJellyfish.transform.position.x;
                    lastYPosition = newJellyfish.transform.position.y;
                }
                else if(-edgeDistance > lastXPosition)
                {
                    GameObject newJellyfish = Instantiate(jellyfishToMake,new Vector2(lastXPosition + Random.Range(0f,10f),lastYPosition + Random.Range(3f,5f)),gameObject.transform.rotation);
                    lastXPosition = newJellyfish.transform.position.x;
                    lastYPosition = newJellyfish.transform.position.y;
                }
                else
                {

                    GameObject newJellyfish = Instantiate(jellyfishToMake,new Vector2(lastXPosition + Random.Range(-10f,0f),lastYPosition + Random.Range(3f,5f)),gameObject.transform.rotation);
                    lastXPosition = newJellyfish.transform.position.x;
                    lastYPosition = newJellyfish.transform.position.y;
                }
                if(!(edgeDistance < lastXPosition2) && !(-edgeDistance > lastXPosition2))
                {
                    GameObject newJellyfish = Instantiate(jellyfishToMake,new Vector2(lastXPosition2 + Random.Range(-8f,0f),lastYPosition2 + Random.Range(3f,5f)),gameObject.transform.rotation);
                    lastXPosition2 = newJellyfish.transform.position.x;
                    lastYPosition2 = newJellyfish.transform.position.y;
                }
                else if(-edgeDistance > lastXPosition2)
                {
                    GameObject newJellyfish = Instantiate(jellyfishToMake,new Vector2(lastXPosition2 + Random.Range(10f,10f),lastYPosition2 + Random.Range(3f,5f)),gameObject.transform.rotation);
                    lastXPosition2 = newJellyfish.transform.position.x;
                    lastYPosition2 = newJellyfish.transform.position.y;
                }
                else
                {

                    GameObject newJellyfish = Instantiate(jellyfishToMake,new Vector2(lastXPosition2 + Random.Range(-10f,0f),lastYPosition2 + Random.Range(3f,5f)),gameObject.transform.rotation);
                    lastXPosition2 = newJellyfish.transform.position.x;
                    lastYPosition2 = newJellyfish.transform.position.y;
                }

            }
            while(lastYPosition < maxHeight);

        }
    }
}