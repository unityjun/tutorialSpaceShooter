using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float liveTime;

	void Start () {
		Destroy(gameObject,liveTime);
	}
}
