using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainManager : MonoBehaviour {
	public Transform terrainPrefab;
	void Start(){

	}

	void Update(){


	}

	void OnTriggerEnter(Collider col){
		Instantiate (terrainPrefab, new Vector3 (-50.0f, -0.01f,transform.parent.position.z +90.0f), terrainPrefab.rotation);
		transform.parent.gameObject.AddComponent<DestroyTerrain> ();
	}
}