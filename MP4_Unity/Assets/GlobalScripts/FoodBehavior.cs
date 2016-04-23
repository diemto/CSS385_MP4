using UnityEngine;
using System.Collections;

public class FoodBehavior : MonoBehaviour {

	enum FoodState {
		NormalState,
		BadState
	};

	FoodState current_state = FoodState.NormalState;

	void Start () {
		NewPosition ();
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
