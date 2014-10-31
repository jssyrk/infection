using UnityEngine;
using System.Collections;

public class SpawnerObject : MonoBehaviour {

	public string pooledObjectName = "";

	private Transform mTransform;

	void Start(){
		mTransform = transform;
	}

	public void Spawn(){
		if(pooledObjectName != ""){
			GameObject g = PoolManager.current.GetPooledObject(pooledObjectName);

			if(g != null){
				g.transform.position = mTransform.position;
				g.transform.rotation = mTransform.rotation;
				g.SetActive(true);
			}
		}
	}
}
