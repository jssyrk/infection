using UnityEngine;
using System.Collections;

public class SpawnerObject : MonoBehaviour {

	public GameObject objectPrefab;

	private Transform mTransform;

	void Start(){
		mTransform = transform;
	}

	public void Spawn(){
		Instantiate (objectPrefab, mTransform.position, mTransform.rotation);
	}
}
