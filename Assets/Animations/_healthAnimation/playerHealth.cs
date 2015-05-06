using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public float level = 0;

	private Animator animator;

	public void Start(){

		animator = this.GetComponent<Animator>();

	}

	public void SetLevel(float L){
		level = L;
	}

	public float SetLevel(){
		return level;
	}

	public void FixedUpdate(){

		animator.SetFloat("level",level);

	}
}
