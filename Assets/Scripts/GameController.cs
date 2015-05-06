using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float startWait;
	public float waveWait;
	
	private bool gameOver;
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

		StartCoroutine(SpawnWaves());
	}

	void Update(){
		//menu
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("Menu");
		}
	}
	
	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(startWait);
		while(true){
			//
			StartCoroutine(spawnWavesScript.StartWave());

			yield return new WaitForSeconds(waveWait);

			if(gameOver){
				break;
			}
		}
	}

	public void RestartLevel(){
		//
		GameOver (false);
		//
		Application.LoadLevel(Application.loadedLevel);
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}

	public void GameOver(bool val = true){
		gameOver = val;
		guiControllerScript.GameOver (gameOver);
	}

	void UpdateScore(){
		guiControllerScript.UpdateScore (score);
	}

}
