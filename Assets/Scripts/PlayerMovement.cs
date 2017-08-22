using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;

	public GameObject player;

	public AudioClip squished;

	//private Transform player;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;

	/// <summary>
	/// The GameManager class to access methods.
	/// </summary>
	private GameManager gm;

	/// <summary>
	/// True if Player should move on user input.
	/// False if Player should not move on user input.
	/// </summary>
	bool isControllable;

	/// <summary>
	/// The name of the constant Run Transition in Animator
	/// </summary>
	const string k_RunTransitionName = "IsRunning";
	/// <summary>
	/// The name of the constant Death Transition in Animator
	/// </summary>
	const string k_DeathTransitionName = "IsDead";
	/// <summary>
	/// The name of the car tag.
	/// </summary>
	const string car_tag = "car";

	// initial
	void Start()
	{
		InvokeRepeating ("SetSpeed", 10f, 10f);

		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody>();

		// Get the script of the Class, GameManager
		gm = (GameManager) GameObject.Find("GameManager").GetComponent("GameManager");

		// Player is allowed to move when game starts
		isControllable = true;
		// Player animation should not be dead on Start
		anim.SetBool(k_DeathTransitionName, false);
	}//END OF Start()

	// physic update
	void FixedUpdate ()
	{
		if (isControllable)
		{// User input is accepted, thus move player
			float h = Input.GetAxisRaw ("Horizontal");

			movement.Set (h, 0f, 1f);
			movement = movement.normalized * speed * Time.fixedDeltaTime;
			playerRigidbody.MovePosition (transform.position + movement);
		}

		bool running = true;
		anim.SetBool (k_RunTransitionName, running);
	}//END OF FixedUpdate()

	void SetSpeed()
	{
		if (speed <= 15)
			speed += 0.5f;		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == car_tag)
		{// Equivalent to death			
			// Disable player movement
			SetIsControllable(false);		
			// Play Death animation
			anim.SetBool(k_DeathTransitionName, true);
			// Play the Death sound at the Player's position
			AudioSource.PlayClipAtPoint(squished, transform.position);
			// Call GameManager to handle other GameObjects not related to Player
			gm.OnDeathPause();
		}//End of if Player collided with a car	
	}//END OF OnTriggerEnter(Collider)

	public void SetIsControllable(bool isControl)
	{
		isControllable = isControl;
	}//END OF SetIsControllable(bool)
}






