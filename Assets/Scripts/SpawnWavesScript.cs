using UnityEngine;
using System.Collections;

public class SpawnWavesScript : MonoBehaviour {
	
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GameObject Asteroid;
	public Transform[] spawnPoints;

	public IEnumerator StartWave(){

		ArrayList indexesSpawnPoints = new ArrayList ();
		foreach(Transform p in spawnPoints){
			indexesSpawnPoints.Add(p);
		}

		while(indexesSpawnPoints.Count > 0){
			Transform point = TakeSpawnPoint(ref indexesSpawnPoints);
			ShootAsteroid(point);
			//
			yield return new WaitForSeconds(spawnWait);
		}
	}

	void ShootAsteroid(Transform point){

		Vector3 spawnPosition = new Vector3(point.position.x,point.position.y,point.position.z);
		Quaternion spawnRotation = Quaternion.identity;
		//
		GameObject asteroid = (GameObject)Instantiate(Asteroid,spawnPosition,spawnRotation);
		Mover mover = asteroid.GetComponent<Mover>();
		mover.Move (asteroid.transform.right);
	}

	Transform TakeSpawnPoint(ref ArrayList aL){

		int i = Random.Range (0, aL.Count - 1);

		Transform point = (Transform)aL[i];
		aL.RemoveAt (i);

		return point;
	}
}
