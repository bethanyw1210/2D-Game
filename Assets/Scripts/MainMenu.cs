using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int levelToLoad;

	// Load game from main menu
	public void EnterLevel() {
        SceneManager.LoadScene("Game");
	}
	
    public void LevelExit()
    {
        Application.Quit();
    }
}
