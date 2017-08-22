using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	private float currentTime;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime > 20f) {
			Destroy (gameObject);

		}
	}
}
