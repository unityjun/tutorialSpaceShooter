using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public int scoreValue;

	private GameControllerScript gameControllerScript;

	void Awake(){

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		gameControllerScript = gameControllerObject.GetComponent<GameControllerScript>();
	}

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Boundary"){
			return;
		}

		//destroy with explotion
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
		//score
		gameControllerScript.AddScore(scoreValue);

		if(other.tag != "Player"){
			//
			Destroy(other.gameObject);
		}
	}
}
