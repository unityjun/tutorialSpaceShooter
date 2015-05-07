using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIControllerScript : MonoBehaviour {

	public GameObject canvasGUI;

	private int Score;

	private Animator canvasAnimator;
	private Text GUIScoreText;
	private Text GUIGameOverText;

	void Awake(){
		//
		canvasAnimator = canvasGUI.GetComponent<Animator>();
		GUIScoreText = (Text)GameObject.FindWithTag ("GUIScoreText").GetComponent<Text> ();
		GUIGameOverText = (Text)GameObject.FindWithTag ("GUIGameOverText").GetComponent<Text> ();

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
		canvasAnimator.SetBool("showResetButton",true);
	}

}
