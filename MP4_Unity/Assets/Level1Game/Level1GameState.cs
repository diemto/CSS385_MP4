using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  
        // for SceneManager


public class Level1GameState : MonoBehaviour {
    public GameObject gameWinPanel;
    const float SEC_TO_SPAWN_FOOD = 1f;
    int game_ticks_since_spawn = 0;
    Text score;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<Text>();
        FirstGameManager.TheGameState.UpdateWorldWindowBound();
        Debug.Log("Level1: Wakes up!!");
		for(int i = 0; i < 5; i++){
			FirstGameManager.TheGameState.CreateNewFoodItem ();
		}
    }

    // Update is called once per frame
    void Update () {
        this.score.text = "Devoured: " + FirstGameManager.TheGameState.GetScore().ToString();

        if (++game_ticks_since_spawn * Time.deltaTime > SEC_TO_SPAWN_FOOD)
        {
            FirstGameManager.TheGameState.CreateNewFoodItem();
            this.game_ticks_since_spawn = 0;
        }

        if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("MenuLevel");    // this must be call from an object in this level!
			FirstGameManager.TheGameState.SetCurrentLevel ("MenuLevel");
			FirstGameManager.TheGameState.PrintCurrentLevel ();
		}

		if (FirstGameManager.TheGameState.GetScore() >= 5) {
            gameWinPanel.SetActive(true);   // Activate the Game Win Panel
            Time.timeScale = 0;     // Pause the scene
        }
	}

    // This method is for attach to the continue onClick() of the button to load the next scene
    // A GameObject with this script attached to it is required. In this case, "ForContinueBtn" in Level1Scene
    public void LoadNextLevel()
    {
        gameWinPanel.SetActive(false);  // Turn off the Game win panel
        SceneManager.LoadScene("LevelTwo");    // this must be call from an object in this level!
        FirstGameManager.TheGameState.SetCurrentLevel("LevelTwo");
        FirstGameManager.TheGameState.PrintCurrentLevel();
    }
}