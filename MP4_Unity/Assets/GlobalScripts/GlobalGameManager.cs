using UnityEngine;
using UnityEngine.SceneManagement;
// for SceneManager
using System.Collections;

public class GlobalGameManager : MonoBehaviour {

	private string mCurrentLevel = "MenuLevel";  //  

	private GameObject food_item;

	// Use this for initialization
	void Start () {
		if (null == this.food_item)
			this.food_item = Resources.Load ("Prefabs/Food") as GameObject;
		DontDestroyOnLoad(this);
	}

	public void CreateNewFoodItem() {
		GameObject e = Instantiate(this.food_item) as GameObject;
	}

	// 
	public void SetCurrentLevel(string level) {
		mCurrentLevel = level;
    }

	public void PrintCurrentLevel()
	{
		Debug.Log("Current Level is: " + mCurrentLevel);
	}
}
