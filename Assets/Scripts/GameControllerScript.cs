using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	private int score;

	private SpawnWavesScript spawnWavesScript;
	private GUIControllerScript guiControllerScript;

	void Awake(){
		//
		GameObject spawnWavesController = GameObject.FindWithTag ("SpawnWavesController");
		spawnWavesScript = spawnWavesController.GetComponent<SpawnWavesScript>();
		//
		guiControllerScript = GetComponent<GUIControllerScript>();
	}

	void Start(){
		score = 0;
		UpdateScore();

		spawnWavesScript.StartWave();
	}

	void Update(){
		//menu
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("Menu");
		}
	}

	public void RestartLevel(){

		Application.LoadLevel(Application.loadedLevel);

	}

	public void GameOver(){
		spawnWavesScript.GameOver ();
		guiControllerScript.GameOver ();
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore(){
		guiControllerScript.UpdateScore (score);
	}

}
