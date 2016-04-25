using UnityEngine;
using UnityEngine.SceneManagement;
// for SceneManager
using System.Collections;

public class Level1HeroControl : MonoBehaviour {

	#region user control references
	private float kHeroSpeed = 15f;
	private bool isMovingRight;
	#endregion
	// Use this for initialization
	void Start () {
		// initialize projectile spawning
		isMovingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		#region user movement control
		transform.position += Input.GetAxis ("Vertical")  * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
		transform.position += Input.GetAxis ("Horizontal")  * transform.right * (kHeroSpeed * Time.smoothDeltaTime);
		#endregion

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
        // todo find out how to get the width of the object and subtract it from the position
		if (this.transform.position.y > FirstGameManager.TheGameState.WorldMax.y)
			transform.position = new Vector3 (transform.position.x, FirstGameManager.TheGameState.WorldMax.y, 0f);
		if (this.transform.position.y < FirstGameManager.TheGameState.WorldMin.y)
			transform.position = new Vector3 (transform.position.x, FirstGameManager.TheGameState.WorldMin.y, 0f);
		if (this.transform.position.x > FirstGameManager.TheGameState.WorldMax.x)
			transform.position = new Vector3 (FirstGameManager.TheGameState.WorldMax.x, transform.position.y, 0f);
		if (this.transform.position.x < FirstGameManager.TheGameState.WorldMin.x)
			transform.position = new Vector3 (FirstGameManager.TheGameState.WorldMin.x, transform.position.y, 0f);
	}
}
