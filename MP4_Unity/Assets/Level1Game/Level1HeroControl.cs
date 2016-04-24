using UnityEngine;	
using System.Collections;

public class Level1HeroControl : MonoBehaviour {

	#region user control references
	private float kHeroSpeed = 20f;
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

		if(Input.GetAxis("Horizontal") < 0 && isMovingRight) {
			float newX = transform.localScale.x * -1;
			transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
			isMovingRight = false;
		}

		if(Input.GetAxis("Horizontal") > 0 && !isMovingRight) {
			float newX = transform.localScale.x * -1;
			transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
			isMovingRight = true;
		}
		#endregion
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
