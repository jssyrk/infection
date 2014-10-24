using UnityEngine;
using System.Collections;

public class SpawnObjectTimer : MonoBehaviour {

	public float spawnTime = 5.0f;

	private SpawnerObject spawner;

	void Start(){
		spawner = GetComponent<SpawnerObject> ();
		Invoke ("DoSpawn", spawnTime);
	}

	void DoSpawn(){
		spawner.Spawn ();
		Invoke ("DoSpawn", spawnTime);
	}
}
