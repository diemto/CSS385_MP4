using UnityEngine;	
using System.Collections;

public class HeroObject : MonoBehaviour {

	#region user control references
	private float speed;
	private bool isMovingRight;
	#endregion
	// Use this for initialization
	public HeroObject () {
		speed = 15f;
		isMovingRight = true;
	}

	// Update is called once per frame
	void Update () {
		GlobalGameManager.WorldBoundStatus status = FirstGameManager.TheGameState.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
		if (status == GlobalGameManager.WorldBoundStatus.Inside) {
			#region user movement control
			transform.position += Input.GetAxis ("Vertical")  * transform.up * (speed * Time.smoothDeltaTime);
			transform.position += Input.GetAxis ("Horizontal")  * transform.right * (speed * Time.smoothDeltaTime);
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

	void OnMouseOver()
	{
		Debug.Log("Mouse over us!");
	}

	void OnMouseUp()
	{
		Debug.Log("Mouse just came up!");
	}

	void OnMouseDown()
	{
		Debug.Log("Mouse just went down!");
	}
}
