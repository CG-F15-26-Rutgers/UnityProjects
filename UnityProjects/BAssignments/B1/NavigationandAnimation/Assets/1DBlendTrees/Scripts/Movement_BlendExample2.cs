using UnityEngine;
using System.Collections;

public class Movement_BlendExample2 : MonoBehaviour {

	Animator animController;	//holds the player character's animator controller




	//the character's possible movement states
	enum MovementState
	{
		Idle = 0,
		Moving = 1
	}
	
	//holds the player's current enumerated movement state
	MovementState currentMovementState;
	
	// Use this for initialization
	void Start () {
		animController = GetComponent<Animator>();	//initialize the animator controller
	}
	
	// Update is called once per frame
	void Update ()
	{
		//get axis input from player (W, A, S, and D keys/Arrow keys)
		float verticalAxis = Input.GetAxis("Vertical");
		float horizontalAxis = Input.GetAxis("Horizontal");




	}
}