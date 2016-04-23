using UnityEngine;	
using System.Collections;

public class Level1HeroControl : MonoBehaviour {

	public GameObject mProjectile = null;

	#region user control references
	private float kHeroSpeed = 20f;
	private float kHeroRotateSpeed = 90/2f; // 90-degrees in 2 seconds
	#endregion
	// Use this for initialization
	void Start () {
		// initialize projectile spawning
		if (null == mProjectile)
			mProjectile = Resources.Load ("Prefabs/Egg") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		#region user movement control
		transform.position += Input.GetAxis ("Vertical")  * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
		transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (kHeroRotateSpeed * Time.smoothDeltaTime));
		#endregion

		if (Input.GetAxis ("Fire1") > 0f) { // this is Left-Control
			GameObject e = Instantiate(mProjectile) as GameObject;
			EggBehavior egg = e.GetComponent<EggBehavior>(); // Shows how to get the script from GameObject
			if (null != egg) {
				e.transform.position = transform.position;
				egg.SetForwardDirection(transform.up);
			}
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
