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
		GlobalGameManager.WorldBoundStatus status = FirstGameManager.TheGameState.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
		if (status == GlobalGameManager.WorldBoundStatus.Inside) {
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
		} else {
				if (status == GlobalGameManager.WorldBoundStatus.CollideTop)
				transform.position += new Vector3 (0f, -0.1f, 0f);
				else if (status == GlobalGameManager.WorldBoundStatus.CollideBottom)
				transform.position += new Vector3 (0f, 0.1f, 0f);
				else if (status == GlobalGameManager.WorldBoundStatus.CollideRight)
				transform.position += new Vector3 (-0.1f, 0f, 0f);
				else if (status == GlobalGameManager.WorldBoundStatus.CollideLeft)
				transform.position += new Vector3 (0.1f, 0f, 0f);
		}
	}
}
