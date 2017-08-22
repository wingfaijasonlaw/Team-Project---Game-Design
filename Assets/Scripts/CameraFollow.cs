using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls how the camera follows the Player
/// </summary>
public class CameraFollow : MonoBehaviour {
	/// <summary>
	/// The target of the Camera.
	/// </summary>
	public Transform target;
	/// <summary>
	/// Adjust how fast the camera pans
	/// </summary>
	public float smoothing = 5f;

	/// <summary>
	/// The amount of distance behind the target
	/// </summary>
	Vector3 offset;

	/// <summary>
	/// Unity Start Method for Instantiations
	/// </summary>
	void Start()
	{
		offset = transform.position - target.position;
	}

	/// <summary>
	/// Unity FixedUpdate Method
	/// </summary>
	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
