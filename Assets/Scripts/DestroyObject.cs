using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.z > this.transform.position.z)
			Destroy (this.gameObject);
	}
}
