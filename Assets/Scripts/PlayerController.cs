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
	public float TiltHorizontal = 0.5f;
	public float TiltVertical = 3.0f;

	public Boundary boundary;
	public float fireRate;

	private float nextFire;
	private float healthLevel = 10;

	private GameControllerScript gameControllerScript;
	private GUIControllerScript guiControllerScript;
	private AudioSource audioSouce;
	private Rigidbody rigidBody;

	void Awake(){
		//
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameControllerScript = gameControllerObject.GetComponent<GameControllerScript>();
			guiControllerScript = gameControllerObject.GetComponent<GUIControllerScript>();
		}

		//
		audioSouce = GetComponent<AudioSource> ();
		//
		rigidBody = GetComponent<Rigidbody> ();
	}

	public void Start(){

		guiControllerScript.UpdateHealthLevel(healthLevel);

	}

	void Update(){
		
		if (Input.GetButton("Fire1") 
		    && Time.time >= nextFire) {

			//timer
			nextFire = Time.time + fireRate;

			Shoting();
		}
	}

	void Shoting(){
		//ffiiiiireeee!
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		GameObject shootGO = (GameObject)Instantiate(shot, new Vector3(shotSpawn.position.x,0.0f,shotSpawn.position.z), Quaternion.Euler(0.0f,eulerAngles.y,shotSpawn.rotation.z));

		Mover mover = shootGO.GetComponent<Mover>();
		mover.Move (shotSpawn.transform.forward);

		//play shoot sound
		audioSouce.Play();
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal"); //x
		float moveVertical = Input.GetAxis("Vertical"); //z

		//
		Move (moveHorizontal,moveVertical);
		//
		UpdateHealthLevel();
	}

	void Move(float H, float V){

		float xPos = Mathf.Clamp(rigidBody.position.x,boundary.xMin,boundary.xMax);
		float zPos = Mathf.Clamp(rigidBody.position.z,boundary.zMin,boundary.zMax);

		Vector3 movement = new Vector3(H,0.0f,V);
		Vector3 pos = new Vector3(xPos,0.0f,zPos);
		
		rigidBody.velocity = movement * Speed;
		rigidBody.position = pos;

		//rotaion
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		rigidBody.rotation = Quaternion.Euler(eulerAngles.x
		                                      	,eulerAngles.y
		                                      	,TiltVertical * rigidBody.velocity.z);

	}


	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Asteroid"){

			float damage = Random.Range(1,2);

			healthLevel = healthLevel - damage;
			//
			UpdateHealthLevel();
			//
			if(healthLevel <= 0 ){
				gameControllerScript.GameOver();
				PlayerDestroy();
			}
		}
	}

	void UpdateHealthLevel(){

		guiControllerScript.UpdateHealthLevel(healthLevel);

	}

	void PlayerDestroy(){
		//boom!
		Instantiate(playerExplosion, transform.position, transform.rotation);
		//
		Destroy(gameObject);
	}
}
