using UnityEngine;	
using System.Collections;

public class Level1HeroControl : MonoBehaviour {

	#region user control references
	private float kHeroSpeed = 20f;
	private float kHeroRotateSpeed = 90/2f; // 90-degrees in 2 seconds
	#endregion
	// Use this for initialization
	void Start () {
		// initialize projectile spawning

	}
	
	// Update is called once per frame
	void Update () {
		#region user movement control
		transform.position += Input.GetAxis ("Vertical")  * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
		transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (kHeroRotateSpeed * Time.smoothDeltaTime));
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
