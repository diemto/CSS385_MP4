using UnityEngine;
using UnityEngine.SceneManagement;
// for SceneManager
using System.Collections;

public class Level1HeroControl : MonoBehaviour {
	#region user control references
	private float kHeroSpeed = 10f;
	private bool isMovingRight;
    #endregion
    // Use this for initialization
    AudioSource audioEffect = null;

    void Start () {
		// initialize projectile spawning
		isMovingRight = true;
        this.audioEffect = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {

		#region user movement control
		transform.position += Input.GetAxis ("Vertical")  * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
		transform.position += Input.GetAxis ("Horizontal")  * transform.right * (kHeroSpeed * Time.smoothDeltaTime);
        #endregion

        //Keep the Hero within the world bound
        Vector2 worldMin = FirstGameManager.TheGameState.WorldMin;
        Vector2 worldMax = FirstGameManager.TheGameState.WorldMax;

		Vector3 size = GetComponent<Renderer> ().bounds.size;
		float deltaY = size.y/2f;
		float deltaX = size.x/2f;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, worldMin.x + deltaX, worldMax.x - deltaX),
                                        Mathf.Clamp(transform.position.y, worldMin.y + deltaY, worldMax.y - deltaY),
                                        transform.position.z);


        #region user front direction
        if (Input.GetAxis ("Horizontal") < 0 && isMovingRight) {
			float xvalue = transform.localScale.x * -1;
			transform.localScale = new Vector3 (xvalue, transform.localScale.y, transform.localScale.z);
			isMovingRight = false;
		}
		if (Input.GetAxis ("Horizontal") > 0 && !isMovingRight) {
			float xvalue = transform.localScale.x * -1;
			transform.localScale = new Vector3 (xvalue, transform.localScale.y, transform.localScale.z);
			isMovingRight = true;
		}
		#endregion
	}
}
