﻿using UnityEngine;
using UnityEngine.SceneManagement;  
// for SceneManager


public class Level2GameState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Level2: Wakes up!!");
		for(int i = 0; i < 10; i++){
			FirstGameManager.TheGameState.CreateNewFoodItem ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("MenuLevel");    // this must be call from an object in this level!
			FirstGameManager.TheGameState.SetCurrentLevel ("MenuLevel");
			FirstGameManager.TheGameState.PrintCurrentLevel ();
		}

		if (Input.GetKey (KeyCode.O)) {
			SceneManager.LoadScene ("LevelOne");    // this must be call from an object in this level!
			FirstGameManager.TheGameState.SetCurrentLevel ("LevelOne");
			FirstGameManager.TheGameState.PrintCurrentLevel ();
		}
	}
}