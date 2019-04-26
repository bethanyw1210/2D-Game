using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Load game from main menu
	public void EnterGame() {
        SceneManager.LoadScene("MainMenu");
	}
}
