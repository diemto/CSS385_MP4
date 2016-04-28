using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	const int SIZE_OF_SCORE = 20;
	const int COL_WIDTH = 10;
	GameObject[] first_line;
	private GameObject point;


	// Use this for initialization
	void Start () {
		if (this.point == null)
			this.point = Resources.Load ("Prefabs/Point") as GameObject;
		this.first_line = new GameObject[SIZE_OF_SCORE];

		Vector3 size = point.GetComponent<Renderer> ().bounds.size;
		float world_top = FirstGameManager.TheGameState.WorldMax.y;
		float world_left = FirstGameManager.TheGameState.WorldMin.x;
		for (int i = 0; i < SIZE_OF_SCORE; i++) {
			this.first_line [i] = Instantiate(this.point) as GameObject;
			this.first_line [i].GetComponent<Renderer> ().enabled = false;
			if (i < COL_WIDTH) {
				this.first_line [i].transform.position = 
						new Vector3 (world_left + i * size.x / 2.5f + size.x / 2f, world_top - size.y / 2.5f, 0);
			} else {
				this.first_line [i].transform.position = 
						new Vector3 (world_left + i % COL_WIDTH * size.x / 2.5f + size.x / 2f, world_top - size.y / 2.5f * 2f, 0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.update_score ();
	}

	private void turn_off_all_score() {
		for (int i = 0; i < SIZE_OF_SCORE; i++) {
			this.first_line [i].GetComponent<Renderer> ().enabled = false;
		}
	}

	private void update_score() {
		int score = FirstGameManager.TheGameState.GetScore ();
		if (score >= SIZE_OF_SCORE)
			return;
		for (int i = 0; i < score; i++) {
			this.first_line [i].GetComponent<Renderer> ().enabled = true;
		}
		for (int i = score; i < SIZE_OF_SCORE; i++) {
			this.first_line [i].GetComponent<Renderer> ().enabled = false;
		}
	}
}
