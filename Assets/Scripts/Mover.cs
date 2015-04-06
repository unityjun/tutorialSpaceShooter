using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = Speed * transform.forward;
	}
}
