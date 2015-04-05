using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

public class PlayerController : MonoBehaviour {

	public GameObject UIPlayerHealth;
	public GameObject shot;
	public GameObject playerExplosion;
	public Transform shotSpawn;

	public float Speed = 1.0f;
	public float TiltHorizontal = 3.0f;
	public float TiltVertical = 1.0f;

	public Boundary boundary;
	
	public float fireRate;

	private float nextFire;
	private playerHealth uiPlayerHealthScript;
	private float healthLevel = 10;

	private GameController gameController;

	public void Start(){

		//
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		uiPlayerHealthScript = UIPlayerHealth.GetComponent<playerHealth>() as playerHealth;
		uiPlayerHealthScript.SetLevel(healthLevel);

	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis("Horizontal"); //x
		float moveVertical = Input.GetAxis("Vertical"); //z

		float xPos = Mathf.Clamp(rigidbody.position.x,boundary.xMin,boundary.xMax);
		float zPos = Mathf.Clamp(rigidbody.position.z,boundary.zMin,boundary.zMax);

		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
		Vector3 pos = new Vector3(xPos,0.0f,zPos);

		rigidbody.velocity = movement * Speed;
		rigidbody.position = pos;
		rigidbody.rotation = Quaternion.Euler(-TiltVertical * rigidbody.velocity.z,0.0f,-TiltHorizontal * rigidbody.velocity.x);

		//
		UpdateHealthLevel();
	}

	void Update(){

		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, new Vector3(shotSpawn.position.x,0.0f,shotSpawn.position.z), Quaternion.Euler(0.0f,0.0f,shotSpawn.rotation.z));
			audio.Play();
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Asteroid"){
			float damage = Random.Range(1,2);
			healthLevel = healthLevel - damage;
			//
			UpdateHealthLevel();
			//
			if(healthLevel <= 0 ){
				gameController.GameOver();
				PlayerDestroy();
			}
		}
	}

	void UpdateHealthLevel(){
		uiPlayerHealthScript.SetLevel(healthLevel);
	}

	void PlayerDestroy(){
		Instantiate(playerExplosion, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
