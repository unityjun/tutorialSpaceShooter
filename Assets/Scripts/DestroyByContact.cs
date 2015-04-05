using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	private GameController gameController;

	public int scoreValue;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController != null){
			//Debug.Log("Cannot find <GameController> script");
		}
	}

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Boundary"){
			return;
		}

		//destroy with explotion
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
		//score
		gameController.AddScore(scoreValue);

		if(other.tag != "Player"){
			//
			Destroy(other.gameObject);
		}
	}
}
