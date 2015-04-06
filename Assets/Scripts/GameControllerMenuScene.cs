using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerMenuScene : MonoBehaviour {

	public GameObject GUIMenu;

	private Animator animatorComponent;

	public void Start(){
		//initialize
		animatorComponent = GUIMenu.GetComponent<Animator>();
		animatorComponent.SetBool("showMenu",true);
	}
	
	public void Update(){
		if (Input.GetKeyDown(KeyCode.P)){
			Animator animatorComponent = GUIMenu.GetComponent<Animator>();
			animatorComponent.SetBool("showMenu",!animatorComponent.GetBool("showMenu"));
		}
	}

	public void StartGame(){
		WaitForAnimation(animatorComponent.GetComponent<Animation>());
		Application.LoadLevel("mainScene");
	}
	
	private IEnumerator WaitForAnimation ( Animation animation )
	{
		do
		{
			yield return null;
		} while ( animation.isPlaying );
	}

}
