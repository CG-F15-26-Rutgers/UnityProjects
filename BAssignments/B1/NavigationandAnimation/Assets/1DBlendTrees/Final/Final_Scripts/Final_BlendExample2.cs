using UnityEngine;
using System.Collections;

public class Final_BlendExample2 : MonoBehaviour {

	Animator animController;	//holds the player character's animator controller

	public float turnIncrement;		//the rate at which we increase/decrease player turn angle
	public float currentTurnAngle;	////the current turn angle of the character

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

		//if there is any player input...
		if (verticalAxis != 0)
		{
			//if player input is negative on the horizontal axis (pressing A)...
			//AND the current turn angle is greater than our lowest blend threshold...
			if (horizontalAxis < 0 && currentTurnAngle > -3)
			{
					currentTurnAngle -= turnIncrement;	//decrease the turn angle by turnIncrement
			}
			//if player input is positive on the horizontal axis (pressing D)...
			//AND the current turn angle is less than our highest blend threshold...
			else if (horizontalAxis > 0 && currentTurnAngle < 3)
			{
				currentTurnAngle += turnIncrement;		//increase the turn angle by turnIncrement
			}
			//if there is forward input, but no turn input...
			else
			{
				//if there is still turning on the negative axis...
				if (currentTurnAngle < 0)
					currentTurnAngle += turnIncrement;	//decrease the turn angle until it reaches 0
				//if there is still turning on the positive axis...
				else if (currentTurnAngle > 0)
					currentTurnAngle -= turnIncrement;	//decrease the turn angle until it reaches 0
			}

			//always set the player state to moving if there is any input
			currentMovementState = MovementState.Moving;
		}
		else	//default to idle if no input
		{
			currentTurnAngle = 0;	//resets the currentTurnAngle to 0 so that new idle position faces 'straight'
			currentMovementState = MovementState.Idle;	//set movement state to idle if no input
		}
		
		//send the current movement state to our character controller
		animController.SetInteger("MovementState", (int)currentMovementState);

		//send the current turn angle to our character controller
		animController.SetFloat("TurnDirection", currentTurnAngle);
	}
}