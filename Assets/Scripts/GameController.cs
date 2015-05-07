using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private bool gameOver = false;
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
		gameOver = false;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}

	public void GameOver(){
		gameOver = true;

		spawnWavesScript.GameOver ();
		guiControllerScript.GameOver ();
	}

	void UpdateScore(){
		guiControllerScript.UpdateScore (score);
	}

}
