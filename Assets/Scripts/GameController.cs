using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public int hazarCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText gameOverText;

	public GameObject GUIMenu;

	private bool gameOver;
	private int score;
	
	void Start(){

		gameOver = false;

		gameOverText.text = "";

		score = 0;
		UpdateScore();

		StartCoroutine(SpawnWaves());
	}

	void Update(){
		//menu
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("mainMenu");
		}

	}

	public void RestartLevel(){

		Animator animatorComponent = GUIMenu.GetComponent<Animator>();
		animatorComponent.SetBool("showResetButton",false);

		Application.LoadLevel(Application.loadedLevel);
	}

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0;i<hazarCount;i++){
				float xRandom = Random.Range(-spawnValues.x,spawnValues.x);
				
				Vector3 spawnPosition = new Vector3(xRandom,spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				//
				Instantiate(hazard,spawnPosition,spawnRotation);
				//
				yield return new WaitForSeconds(spawnWait);
			}
			//
			yield return new WaitForSeconds(waveWait);

			if(gameOver){
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}

	public void GameOver(){

		//
		Animator animatorComponent = GUIMenu.GetComponent<Animator>();
		animatorComponent.SetBool("showResetButton",true);

		gameOver = true;
		gameOverText.text = "Game Over!";
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

}
