using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = Speed * transform.forward;
	}
}
