using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIControllerScript : MonoBehaviour {

	public GameObject canvasGUI;

	private int Score;
	private bool gameOver;

	private Animator canvasAnimator;
	private GameObject GUIScoreText;
	private GameObject GUIGameOverText;

	void Awake(){
		//
		canvasAnimator = canvasGUI.GetComponent<Animator>();
		GUIScoreText = GameObject.FindWithTag ("GUIScoreText");
		GUIGameOverText = GameObject.FindWithTag ("GUIGameOverText");
	}

	public void UpdateScore(int val){
		Score += (int)val;
		UpdateScoreText ();
	}

	void UpdateScoreText(){
		Text text = GUIScoreText.GetComponent<Text> ();
		text.text = "Score: " + Score.ToString();
	}

	public void GameOver(bool val){
		gameOver = val;

		GUIGameOverText.SetActive(gameOver);
		canvasAnimator.SetBool("showResetButton",gameOver);
	}

}
