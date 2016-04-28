using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  
// for SceneManager


public class Level2GameState : MonoBehaviour {
    public GameObject WiningPanel = null;
    public Button mExit = null;
    public Button replay = null;
	const float SEC_TO_SPAWN_FOOD = 1f;
	int game_ticks_since_spawn = 0;
	Text score;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1; // Resume the game scene
        score = GameObject.Find("Score").GetComponent<Text>();
		FirstGameManager.TheGameState.UpdateWorldWindowBound();
		Debug.Log("Level2: Wakes up!!");
		for(int i = 0; i < 5; i++){
			FirstGameManager.TheGameState.CreateNewFoodItem ();
		}
        mExit.onClick.AddListener(
                () => {                     // Lamda operator: define an annoymous function
                    Debug.Log("mExit button clicked");
                    WiningPanel.SetActive(false);
                    Application.Quit();
                });
        replay.onClick.AddListener(
                () => {                     // Lamda operator: define an annoymous function
                    Debug.Log("loadLevel button clicked");
                    WiningPanel.SetActive(false);
                    FirstGameManager.TheGameState.SetScore(0);
                    Time.timeScale = 1; // turn on timescale back to on
                    SceneManager.LoadScene("LevelOne");
                });
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

		if (FirstGameManager.TheGameState.GetScore() >= 20) {
            // Show winning screen
            WiningPanel.SetActive(true);    // Activate the winning panel
            Time.timeScale = 0;             // Pause the scene (turn time scale off)
		}

        
    }
}