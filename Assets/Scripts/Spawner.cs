using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Spawner:MonoBehaviour
    {
        public float minDistance = 1, maxDistance = 10, lastXPosition, lastYPosition, lastXPosition2, lastYPosition2, edgeDistance = 10f, maxHeight = 30;
        public int jellyfishCount, whichjellyfish, whichBadGuy;
        public int level;
        public GameObject jellyfish1, jellyfish2, jellyfish3, jellyfishToMake, enemyToMake;

        // Use this for initialization
        void Start()
        {
            level = 1;
            lastYPosition = -15f;
            BringOnTheJellies();
        edgeDistance = Camera.main.orthographicSize*.8f;
        }

        // JellySpawner
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
            whichBadGuy = Random.Range(1,30);
            switch(whichBadGuy)
            {
                case 9:
                case 10:
                case 11:
                    enemyToMake = GameObject.Find("Shark");
                    Instantiate(enemyToMake,new Vector2(-18,lastYPosition + Random.Range(3f,5f)),gameObject.transform.rotation);
                    break;
                case 16:
                case 17:
                case 18:
                    enemyToMake = GameObject.Find("Swordfish");
                    Instantiate(enemyToMake,new Vector2(-18,lastYPosition + Random.Range(3f,5f)),gameObject.transform.rotation);
                    break;
                case 3:
                    enemyToMake = GameObject.Find("Powerup Bubble Gun");
                    Instantiate(enemyToMake,new Vector2(lastXPosition,lastYPosition +2),gameObject.transform.rotation);
                    break;
                case 4:
                    enemyToMake = GameObject.Find("Powerup Turtle");
                    Instantiate(enemyToMake,new Vector2(lastXPosition,lastYPosition + 2),gameObject.transform.rotation);
                    break;
                case 5:
                    enemyToMake = GameObject.Find("Powerup School");
                    Instantiate(enemyToMake,new Vector2(lastXPosition,lastYPosition + 2),gameObject.transform.rotation);
                    break;
                case 6:
                    enemyToMake = GameObject.Find("Powerup Bubble Gun");
                    Instantiate(enemyToMake,new Vector2(lastXPosition2,lastYPosition2 + 2),gameObject.transform.rotation);
                    break;
                case 7:
                    enemyToMake = GameObject.Find("Powerup Turtle");
                    Instantiate(enemyToMake,new Vector2(lastXPosition2,lastYPosition2 + 2),gameObject.transform.rotation);
                    break;
                case 8:
                    enemyToMake = GameObject.Find("Powerup School");
                    Instantiate(enemyToMake,new Vector2(lastXPosition2,lastYPosition2 + 2),gameObject.transform.rotation);
                    break;
                case 23:
                    enemyToMake = GameObject.Find("Coin");
                    Instantiate(enemyToMake,new Vector2(lastXPosition,lastYPosition + 2),gameObject.transform.rotation);
                    print("You collected a coin!");
                    break;
                case 24:
                    enemyToMake = GameObject.Find("Coin");
                    Instantiate(enemyToMake,new Vector2(lastXPosition2,lastYPosition2 + 2),gameObject.transform.rotation);
                    print("You collected a coin!");
                    break;
                default:
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
