using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSceneController : MonoBehaviour {

	public GameObject GUIMenu;

	private Animator animatorComponent;
	void Awake(){
		//initialize
		animatorComponent = GUIMenu.GetComponent<Animator>();
	}

	public void Start(){
		animatorComponent.SetBool("showMenu",true);
	}
	
	public void Update(){
		if (Input.GetKeyDown(KeyCode.P)){
			animatorComponent.SetBool("showMenu",!animatorComponent.GetBool("showMenu"));
		}
	}

	public void StartGame(){
		WaitForAnimation(animatorComponent.GetComponent<Animation>());
		Application.LoadLevel("Scene_01");
	}
	
	private IEnumerator WaitForAnimation ( Animation animation )
	{
		do{
			yield return null;
		} while ( animation.isPlaying );
	}

}
