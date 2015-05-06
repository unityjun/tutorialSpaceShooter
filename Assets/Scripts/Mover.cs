using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float Speed;

	private Rigidbody rigidBody;

	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		//Move (-1.0f*transform.right);
	}

	public void Move(Vector3 direction){

		rigidBody.velocity = Speed * direction;

	}
}
