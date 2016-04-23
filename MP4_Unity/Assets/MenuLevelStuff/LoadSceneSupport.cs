using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// for SceneManager

public class LoadSceneSupport : MonoBehaviour {

	public string LevelName = null;

    public Button mLevelOneButton;
    public Button mLevelTwoButton;

	// Use this for initialization
	void Start () {
        // Workflow assume:
        //      mLevelOneButton: is dragged/placed from UI
        mLevelTwoButton = GameObject.Find("Start").GetComponent<Button>();

        // add in listener
        mLevelOneButton.onClick.AddListener(
                () => {                     // Lamda operator: define an annoymous function
                    Debug.Log("Button 1");
                    LoadScene("LevelOne");
                });  

        mLevelTwoButton.onClick.AddListener(ButtonTwoService);
	}

    #region Button service function
        private void ButtonTwoService() {
            Debug.Log("Button 2");
            LoadScene("LevelTwo");
        }
    #endregion

    // Update is called once per frame
    void Update () {
	
	}
    
	void LoadScene(string theLevel) {
        SceneManager.LoadScene(theLevel);
		FirstGameManager.TheGameState.SetCurrentLevel(theLevel);
		FirstGameManager.TheGameState.PrintCurrentLevel();
	}
}