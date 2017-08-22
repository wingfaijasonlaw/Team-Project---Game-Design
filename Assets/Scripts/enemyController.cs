using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour 
{
	private float speed = -5.0f;

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.forward*speed * Time.deltaTime, Space.World);
	}
}
