using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodBehavior : MonoBehaviour {

	enum FoodState {
		NormalState,
		BadState
	};

	enum FoodImage {
		CupCake,
		CupCakeBad,
		IceCream,
		IceCreamBad,
		ShavedIce,
		ShavedIceBad
	};

	FoodImage current_img;

	Dictionary<FoodImage, string> img_table;

	FoodState current_state = FoodState.NormalState;

	void Start () {
		NewPosition ();
		img_table = new Dictionary<FoodImage, string> ();
		img_table.Add (FoodImage.CupCake, "SharedTextures/cupcake");
		img_table.Add (FoodImage.CupCakeBad, "SharedTextures/cupcake_bad");
		img_table.Add (FoodImage.IceCream, "SharedTextures/iceCream");
		img_table.Add (FoodImage.IceCreamBad, "SharedTextures/iceCream_bad");
		img_table.Add (FoodImage.ShavedIce, "SharedTextures/shavedIce");
		img_table.Add (FoodImage.ShavedIceBad, "SharedTextures/shavedIce_bad");
		current_img = (FoodImage)(Random.Range (0, 3) * 2);
		Debug.Log (img_table [current_img]);

		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		if (null != renderer) {
			Sprite s = Resources.Load (img_table[current_img], typeof(Sprite)) as Sprite;
			renderer.sprite = s;
		}
	}

	// Update is called once per frame
	void Update () {
		switch (this.current_state) {
		case FoodState.NormalState:
			this.ServiceNormalState ();
			break;
		case FoodState.BadState:
			this.ServiceBadState ();
			break;
		}
	}

	private void ServiceNormalState() {
		//GameObject hero = GameObject.Find ("Hero");
	}

    private void MoveSelf()
    {
    }

	private void ServiceBadState() {
    }


	private void NewPosition() {
		Vector2 worldMin = FirstGameManager.TheGameState.WorldMin;
		Vector2 worldMax = FirstGameManager.TheGameState.WorldMax;
		float x_pos = Random.Range (worldMin.x, worldMax.x);
		float y_pos = Random.Range (worldMin.y, worldMax.y);
		transform.position = new Vector3 (x_pos, y_pos, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Level1Hero") {
            //GlobalBehavior globalBehavior = GameObject.Find("GameManager").GetComponent<GlobalBehavior>();
            Destroy(this.gameObject);
        }
	}
}
