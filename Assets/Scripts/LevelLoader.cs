using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Script for loading scenes functionality
/// </summary>
public class LevelLoader : MonoBehaviour {
	
	/// <summary>
	/// Load the desired level
	/// </summary>
	/// <param name="scene"></param> Level to be loaded
	public void LoadLevel (int scene) {
		SceneManager.LoadScene(scene);
	}

	/// <summary>
	/// Quit the application
	/// </summary>
	public void Quit () {	
		Application.Quit();
	}

	/// <summary>
	/// Check if user wants to escape from the scene
	/// </summary>
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}
}
