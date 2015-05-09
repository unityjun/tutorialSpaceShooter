using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIControllerScript : MonoBehaviour {

	public GameObject canvasGUI;

	private int Score;
	private float healthLevel;

	private Animator canvasAnimator;
	private Text GUIScoreText;
	private Text GUIGameOverText;
	private Animator guiHealthLevelAnimator;

	void Awake(){
		//
		canvasAnimator = canvasGUI.GetComponent<Animator>();
		GUIScoreText = (Text)GameObject.FindWithTag ("GUIScoreText").GetComponent<Text> ();
		GUIGameOverText = (Text)GameObject.FindWithTag ("GUIGameOverText").GetComponent<Text> ();

		guiHealthLevelAnimator = (Animator)GameObject.FindWithTag ("GUIHealthLevel").GetComponent<Animator> ();

	}

	void Start(){
		//
		GUIGameOverText.text = "";
	}

	public void UpdateScore(int val){
		Score = val;
		UpdateScoreText ();
	}

	void UpdateScoreText(){
		GUIScoreText.text = "Score: " + Score.ToString();
	}

	public void GameOver(){
		GUIGameOverText.text = "Game Over";
		canvasAnimator.SetTrigger("Reset");
	}

	public void UpdateHealthLevel(float level){
		healthLevel = level;
		guiHealthLevelAnimator.SetFloat("level",healthLevel);
	}
}
