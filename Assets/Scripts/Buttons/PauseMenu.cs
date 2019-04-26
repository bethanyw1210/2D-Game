using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu:MonoBehaviour {
    public bool paused = true;
    float timesaver,speedsaver;
    private int currentSceneIndex;

   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                timesaver = Time.timeScale;
                Time.timeScale = 0;
                /*
                currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("SavedScene",currentSceneIndex);
                SceneManager.LoadScene("Pause");
                */
                speedsaver = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().speed;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().speed = 0;
                paused = false;
            }
            else
            {
                Time.timeScale = timesaver;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().speed = speedsaver;
                paused = true;
            }
        }
    }

}

