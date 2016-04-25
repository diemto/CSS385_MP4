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

	int current_img;
	int current_tick = 0;
	const int sec_til_turn_bad = 2;
	const int sec_til_bad_destroyed = 2;

	Dictionary<int, string> img_table;

	FoodState current_state = FoodState.NormalState;

	void Start () {
		NewPosition ();
		img_table = new Dictionary<int, string> ();
		img_table.Add ((int)FoodImage.CupCake, "SharedTextures/cupcake");
		img_table.Add ((int)FoodImage.CupCakeBad, "SharedTextures/cupcake_bad");
		img_table.Add ((int)FoodImage.IceCream, "SharedTextures/iceCream");
		img_table.Add ((int)FoodImage.IceCreamBad, "SharedTextures/iceCream_bad");
		img_table.Add ((int)FoodImage.ShavedIce, "SharedTextures/shavedIce");
		img_table.Add ((int)FoodImage.ShavedIceBad, "SharedTextures/shavedIce_bad");
		this.current_img = (Random.Range (0, 3) * 2);
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		if (null != renderer) {
			Sprite s = Resources.Load (this.img_table[this.current_img], typeof(Sprite)) as Sprite;
			renderer.sprite = s;
		}
	}

	void swap_img() {
		if (this.current_img % 2 == 0)
			this.current_img++;
		else {
			this.current_img--;
		}
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		if (null != renderer) {
			Sprite s = Resources.Load (this.img_table[this.current_img], typeof(Sprite)) as Sprite;
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
		if (this.current_tick * Time.deltaTime > sec_til_turn_bad) {
			this.swap_img ();
			this.current_tick = 0;
			this.current_state = FoodState.BadState;
		}
		++this.current_tick;
	}

    private void MoveSelf()
    {
    }

	private void ServiceBadState() {
		if (this.current_tick * Time.deltaTime > sec_til_bad_destroyed) {
			Destroy (this.gameObject);
		}
		++this.current_tick;
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
            Destroy(this.gameObject);
        }
        if (this.current_state == FoodState.NormalState) FirstGameManager.TheGameState.AddScore();
        else FirstGameManager.TheGameState.MinusScore();
	}
}
