using UnityEngine;
using System.Collections;

public class Final_BlendExample1 : MonoBehaviour {
	
	Transform mainCamera;		//holds the main camera as a Transform object
	Animator animController;	//holds the player character's animator controller

	public float speedIncrement;	//the rate at which we increase/decrease player speed
	public float currentSpeed;		//the current speed of the character

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main.transform;		//initialize the camera's transform
		animController = GetComponent<Animator>();	//initialize the animator controller
	}
	
	// Update is called once per frame
	void Update ()
	{
		//get axis input from player (W, A, S, and D keys/Arrow keys)
		float verticalAxis = Input.GetAxis("Vertical");
		float horizontalAxis = Input.GetAxis("Horizontal");
		
		//get the forward-facing direction of the camera
		Vector3 cameraForward = mainCamera.TransformDirection(Vector3.forward);
		cameraForward.y = 0;	//set to 0 because of camera rotation on the X axis
		
		//get the right-facing direction of the camera
		Vector3 cameraRight = mainCamera.TransformDirection(Vector3.right);
		
		//determine the direction the player will face based on input and the camera's right and forward directions
		Vector3 targetDirection = horizontalAxis * cameraRight + verticalAxis * cameraForward;
		
		//normalize the direction the player should face
		Vector3 lookDirection = targetDirection.normalized;
		
		//rotate the player to face the correct direction ONLY if there is any player input
		if (lookDirection != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(lookDirection);
		
		//if there is any player input...
		if (verticalAxis != 0 || horizontalAxis != 0)
		{
			//if the curent speed is less than our maximum blend threshold...
			if (currentSpeed < 4)
			{
				currentSpeed += speedIncrement;		//increase the speed by speedIncrement
			}
		}
		else	//default to idle if no input
		{
			//if the current speed is greater than 0...
			if (currentSpeed > 0)
				currentSpeed -= speedIncrement;		//decrease the speed until it reaches 0 (idle)
		}

		//send the current movement speed to our character controller
		animController.SetFloat("MoveSpeed", currentSpeed);
	}
}